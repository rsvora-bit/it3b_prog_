from pathlib import Path
import json

ROOT=Path('Projekty/Tideland')

def read(path):
    return (ROOT/path).read_text()

def write(path,text):
    (ROOT/path).write_text(text)

def replace_once(text,old,new,label):
    if old not in text:
        raise SystemExit(f'{label}: expected source text not found')
    return text.replace(old,new,1)

# Keep the currently working world-FOV implementation from main unchanged.
# Expand the Settings model only.
p='src/core/types.ts'
s=read(p)
s=replace_once(s,
"export interface Settings {sensitivity:number; fov:number; masterVolume:number; effectsVolume:number; quality:'low'|'medium'|'high'}",
"export interface Settings {sensitivity:number; fov:number; viewmodelFov:number; invertY:boolean; headBob:boolean; masterVolume:number; effectsVolume:number; quality:'low'|'medium'|'high'; renderScale:number; shadows:boolean; crosshairOpacity:number; showCompass:boolean}",
'core Settings interface')
write(p,s)

p='src/config/balance.ts'
s=read(p)
s=replace_once(s,
"export const DEFAULT_SETTINGS = {sensitivity:1,fov:90,masterVolume:0.65,effectsVolume:0.7,quality:'high' as const};",
"export const DEFAULT_SETTINGS = {sensitivity:1,fov:90,viewmodelFov:50,invertY:false,headBob:false,masterVolume:0.65,effectsVolume:0.7,quality:'high' as const,renderScale:1,shadows:true,crosshairOpacity:1,showCompass:true};",
'default settings')
write(p,s)

p='src/save/storage.ts'
s=read(p)
old="""  return {\n    sensitivity: finite(value.sensitivity, 0.1, 3) ? value.sensitivity : DEFAULT_SETTINGS.sensitivity,\n    fov: finite(value.fov, 55, 110) ? normalizeFov(value.fov) : DEFAULT_SETTINGS.fov,\n    masterVolume: finite(value.masterVolume, 0, 1) ? value.masterVolume : DEFAULT_SETTINGS.masterVolume,\n    effectsVolume: finite(value.effectsVolume, 0, 1) ? value.effectsVolume : DEFAULT_SETTINGS.effectsVolume,\n    quality: value.quality === 'low' || value.quality === 'medium' || value.quality === 'high' ? value.quality : DEFAULT_SETTINGS.quality,\n  };"""
new="""  return {\n    sensitivity: finite(value.sensitivity, 0.1, 3) ? value.sensitivity : DEFAULT_SETTINGS.sensitivity,\n    fov: finite(value.fov, 55, 110) ? normalizeFov(value.fov) : DEFAULT_SETTINGS.fov,\n    viewmodelFov: finite(value.viewmodelFov, 40, 75) ? value.viewmodelFov : DEFAULT_SETTINGS.viewmodelFov,\n    invertY: typeof value.invertY === 'boolean' ? value.invertY : DEFAULT_SETTINGS.invertY,\n    headBob: typeof value.headBob === 'boolean' ? value.headBob : DEFAULT_SETTINGS.headBob,\n    masterVolume: finite(value.masterVolume, 0, 1) ? value.masterVolume : DEFAULT_SETTINGS.masterVolume,\n    effectsVolume: finite(value.effectsVolume, 0, 1) ? value.effectsVolume : DEFAULT_SETTINGS.effectsVolume,\n    quality: value.quality === 'low' || value.quality === 'medium' || value.quality === 'high' ? value.quality : DEFAULT_SETTINGS.quality,\n    renderScale: finite(value.renderScale, 0.5, 1) ? value.renderScale : DEFAULT_SETTINGS.renderScale,\n    shadows: typeof value.shadows === 'boolean' ? value.shadows : DEFAULT_SETTINGS.shadows,\n    crosshairOpacity: finite(value.crosshairOpacity, 0, 1) ? value.crosshairOpacity : DEFAULT_SETTINGS.crosshairOpacity,\n    showCompass: typeof value.showCompass === 'boolean' ? value.showCompass : DEFAULT_SETTINGS.showCompass,\n  };"""
s=replace_once(s,old,new,'settings normalization')
write(p,s)

p='src/player/PlayerController.ts'
s=read(p)
s=replace_once(s,
"look(dx:number,dy:number){this.yaw-=dx*0.002*this.settings.sensitivity;this.pitch=THREE.MathUtils.clamp(this.pitch-dy*0.002*this.settings.sensitivity,-1.48,1.48);this.camera.rotation.order='YXZ';this.camera.rotation.set(this.pitch,this.yaw,0);}",
"look(dx:number,dy:number){this.yaw-=dx*0.002*this.settings.sensitivity;const ySign=this.settings.invertY?1:-1;this.pitch=THREE.MathUtils.clamp(this.pitch+dy*0.002*this.settings.sensitivity*ySign,-1.48,1.48);this.camera.rotation.order='YXZ';this.camera.rotation.set(this.pitch,this.yaw,0);}",
'look invert Y')
s=replace_once(s,
"setSettings(s:Settings){this.settings=s;}",
"setSettings(s:Settings){this.settings=s;this.headBob=s.headBob;}",
'player settings')
write(p,s)

p='src/rendering/HeldItem.ts'
s=read(p)
s=replace_once(s,
"  hit(){this.swing=1;}",
"  setFov(value:number){this.camera.fov=THREE.MathUtils.clamp(value,40,75);this.camera.updateProjectionMatrix();}\n  hit(){this.swing=1;}",
'viewmodel FOV setter')
write(p,s)

p='src/app/GameApp.ts'
s=read(p)
old="private applySettings(s:Settings){this.settings={...s};this.projection.setBaseFov(s.fov);saveSettings(s);this.ui?.setSettings(s);this.audio?.setSettings(s);this.player?.setSettings(s);const dpr=s.quality==='low'?1:s.quality==='medium'?Math.min(devicePixelRatio,1.25):Math.min(devicePixelRatio,1.6);this.renderer.setPixelRatio(dpr);this.renderer.shadowMap.enabled=s.quality!=='low';this.environment?.setQuality(s.quality);this.resize();}"
new="private applySettings(s:Settings){this.settings={...s};this.projection.setBaseFov(s.fov);saveSettings(s);this.ui?.setSettings(s);this.audio?.setSettings(s);this.player?.setSettings(s);this.held.setFov(s.viewmodelFov);const qualityDpr=s.quality==='low'?1:s.quality==='medium'?Math.min(devicePixelRatio,1.25):Math.min(devicePixelRatio,1.6);this.renderer.setPixelRatio(Math.max(.5,qualityDpr*s.renderScale));this.renderer.shadowMap.enabled=s.shadows&&s.quality!=='low';this.environment?.setQuality(s.quality);this.resize();}"
s=replace_once(s,old,new,'GameApp applySettings')
write(p,s)

p='src/ui/UI.ts'
s=read(p)
start=s.index('      <section class="screen settings-screen"')
end=s.index('      <section class="screen dead-screen modal-screen"',start)
settings_section='''      <section class="screen settings-screen" data-view="settings" aria-label="Settings"><header class="overlay-header"><div class="small-brand">${mark}<span>TIDELAND</span><i>/</i><span class="muted">SETTINGS</span></div><button class="close-button" data-action="settingsBack">BACK <span>×</span></button></header><div class="settings-content"><div class="settings-intro"><div class="eyebrow">MAKE YOURSELF AT HOME</div><h2>LIVE<br>PREVIEW<span>.</span></h2><p>Changes apply immediately and save automatically.<br><small>BUILD v${GAME_VERSION} · ${GAME_BUILD}</small></p></div><div class="settings-controls"><h3>CONTROLS & CAMERA</h3>${this.slider('sensitivity','Mouse sensitivity',0.2,3,0.1)}${this.slider('fov','World field of view <small>Uses the current proven camera behaviour</small>',60,100,1)}${this.slider('viewmodelFov','Held-item field of view <small>Changes only hands and equipped tools</small>',40,75,1)}${this.toggle('invertY','Invert vertical look','Reverse mouse Y movement')}${this.toggle('headBob','Head bob','Subtle walking camera motion')}<div class="settings-actions"><button data-action="resetCamera">RESET CAMERA</button></div><h3>AUDIO</h3>${this.slider('masterVolume','Master volume',0,1,0.01)}${this.slider('effectsVolume','Effects volume',0,1,0.01)}<h3>GRAPHICS & HUD</h3><div class="setting-row quality-row"><label>Graphics quality<small>Vegetation and environment detail</small></label><div class="quality-options"><button data-quality="low">LOW</button><button data-quality="medium">MEDIUM</button><button data-quality="high">HIGH</button></div></div>${this.slider('renderScale','Render scale <small>Lower this first if FPS is low</small>',0.5,1,0.05)}${this.toggle('shadows','Dynamic shadows','Disable for a large GPU performance gain')}${this.slider('crosshairOpacity','Crosshair opacity',0,1,0.05)}${this.toggle('showCompass','Compass','Show the navigation strip at the top')}<h3>TROUBLESHOOTING</h3><div class="setting-row setting-buttons"><label>Local settings<small>Useful when two devices behave differently.</small></label><div><button data-action="resetSettings">RESET SETTINGS</button><button data-action="reloadBuild">RELOAD LATEST BUILD</button></div></div><div class="save-reset-row"><span>LOCAL SAVE DATA<small>Remove your saved island and progress.</small></span><button class="danger-button" data-action="reset">RESET SAVE</button></div><div class="reset-confirm" hidden><span>This permanently removes the saved world.</span><button data-action="resetConfirm">DELETE SAVE</button><button data-action="resetCancel">CANCEL</button></div></div></div></section>'''
s=s[:start]+settings_section+'\n\n'+s[end:]

old="""  setSettings(settings: Settings): void {\n    this.settings = {...settings};\n    for (const name of ['sensitivity','fov','masterVolume','effectsVolume'] as const) {\n      const input = this.find<HTMLInputElement>(`input[data-setting=\"${name}\"]`);\n      input.value = String(settings[name]);\n      this.find(`[data-setting-value=\"${name}\"]`).textContent = this.settingValue(name, settings[name]);\n      input.style.setProperty('--range',`${(settings[name] - Number(input.min)) / (Number(input.max) - Number(input.min)) * 100}%`);\n    }\n    this.root.querySelectorAll<HTMLElement>('[data-quality]').forEach(button => button.classList.toggle('active',button.dataset.quality === settings.quality));\n  }"""
new="""  setSettings(settings: Settings): void {\n    this.settings = {...settings};\n    for (const name of ['sensitivity','fov','viewmodelFov','masterVolume','effectsVolume','renderScale','crosshairOpacity'] as const) {\n      const input = this.find<HTMLInputElement>(`input[data-setting=\"${name}\"]`);\n      input.value = String(settings[name]);\n      this.find(`[data-setting-value=\"${name}\"]`).textContent = this.settingValue(name, settings[name]);\n      input.style.setProperty('--range',`${(settings[name] - Number(input.min)) / (Number(input.max) - Number(input.min)) * 100}%`);\n    }\n    this.root.querySelectorAll<HTMLElement>('[data-quality]').forEach(button => button.classList.toggle('active',button.dataset.quality === settings.quality));\n    for(const name of ['invertY','headBob','shadows','showCompass'] as const)this.root.querySelectorAll<HTMLElement>(`[data-toggle=\"${name}\"]`).forEach(button=>button.classList.toggle('active',String(settings[name])===button.dataset.value));\n    this.root.classList.toggle('hide-compass',!settings.showCompass);\n    this.root.style.setProperty('--crosshair-opacity',String(settings.crosshairOpacity));\n  }"""
s=replace_once(s,old,new,'UI setSettings')

old="""      if(target.dataset.quality) {this.settings.quality=target.dataset.quality as Settings['quality'];this.actions.settings({...this.settings});this.setSettings(this.settings);}\n      if(target.dataset.dev) this.actions.dev(target.dataset.dev);"""
new="""      if(target.dataset.quality) {this.settings.quality=target.dataset.quality as Settings['quality'];this.actions.settings({...this.settings});this.setSettings(this.settings);}\n      if(target.dataset.toggle) {const name=target.dataset.toggle as 'invertY'|'headBob'|'shadows'|'showCompass';this.settings[name]=target.dataset.value==='true';this.actions.settings({...this.settings});this.setSettings(this.settings);}\n      if(target.dataset.dev) this.actions.dev(target.dataset.dev);"""
s=replace_once(s,old,new,'UI toggle click handler')

old="""      case 'resetConfirm':this.actions.resetSave();this.find('.reset-confirm').hidden=true;this.setSaveAvailable(false);break;\n      case 'drop':this.actions.dropItem(this.selectedSlot);break;"""
new="""      case 'resetConfirm':this.actions.resetSave();this.find('.reset-confirm').hidden=true;this.setSaveAvailable(false);break;\n      case 'resetCamera':this.settings={...this.settings,sensitivity:DEFAULT_SETTINGS.sensitivity,fov:DEFAULT_SETTINGS.fov,viewmodelFov:DEFAULT_SETTINGS.viewmodelFov,invertY:DEFAULT_SETTINGS.invertY,headBob:DEFAULT_SETTINGS.headBob};this.actions.settings({...this.settings});this.setSettings(this.settings);this.notify('Camera settings restored');break;\n      case 'resetSettings':this.settings={...DEFAULT_SETTINGS};this.actions.settings({...this.settings});this.setSettings(this.settings);this.notify('Settings restored to defaults');break;\n      case 'reloadBuild':{const url=new URL(window.location.href);url.searchParams.set('build',`${GAME_VERSION}-${GAME_BUILD}`);window.location.replace(url.toString());break;}\n      case 'drop':this.actions.dropItem(this.selectedSlot);break;"""
s=replace_once(s,old,new,'UI settings actions')

old="""  private slider(name: string, label: string, min: number, max: number, step: number): string {return `<div class=\"setting-row\"><label for=\"setting-${name}\">${label}</label><div class=\"setting-slider\"><input id=\"setting-${name}\" data-setting=\"${name}\" type=\"range\" min=\"${min}\" max=\"${max}\" step=\"${step}\"><output data-setting-value=\"${name}\"></output></div></div>`;}\n  private settingValue(name: string, value: number): string {return name.includes('Volume')?`${Math.round(value*100)}%`:name==='fov'?`${value}°`:`${value.toFixed(1)}×`;}"""
new="""  private slider(name: string, label: string, min: number, max: number, step: number): string {return `<div class=\"setting-row\"><label for=\"setting-${name}\">${label}</label><div class=\"setting-slider\"><input id=\"setting-${name}\" data-setting=\"${name}\" type=\"range\" min=\"${min}\" max=\"${max}\" step=\"${step}\"><output data-setting-value=\"${name}\"></output></div></div>`;}\n  private toggle(name:'invertY'|'headBob'|'shadows'|'showCompass',label:string,detail:string):string{return `<div class=\"setting-row toggle-row\"><label>${label}<small>${detail}</small></label><div class=\"toggle-options\"><button data-toggle=\"${name}\" data-value=\"false\">OFF</button><button data-toggle=\"${name}\" data-value=\"true\">ON</button></div></div>`;}\n  private settingValue(name: string, value: number): string {if(name.includes('Volume')||name==='crosshairOpacity')return `${Math.round(value*100)}%`;if(name==='fov'||name==='viewmodelFov')return `${Math.round(value)}°`;if(name==='renderScale')return `${Math.round(value*100)}%`;return `${value.toFixed(1)}×`;}"""
s=replace_once(s,old,new,'UI slider/toggle helpers')

old="""if(this.diagnosticVisible) this.find('.diagnostics pre').textContent = `FPS          ${Math.round(hud.fps)}\\nFRAME        ${(1000/Math.max(hud.fps,1)).toFixed(1)} ms"""
new="""if(this.diagnosticVisible) this.find('.diagnostics pre').textContent = `BUILD        v${GAME_VERSION} / ${GAME_BUILD}\\nFPS          ${Math.round(hud.fps)}\\nFRAME        ${(1000/Math.max(hud.fps,1)).toFixed(1)} ms"""
s=replace_once(s,old,new,'diagnostic build id')
write(p,s)

p='src/ui/style.css'
s=read(p)
append='''\n\n/* v0.2.1 expanded settings */\n.crosshair{opacity:var(--crosshair-opacity,1)}\n.tide-ui.hide-compass .compass-wrap{display:none}\n.setting-row label small,.toggle-row label small,.setting-buttons label small{display:block;font-size:9px;line-height:1.45;color:#819875;margin-top:5px;letter-spacing:0}\n.toggle-options{display:flex;gap:4px}\n.toggle-options button,.setting-buttons button,.settings-actions button{font-family:var(--title-font);font-size:10px;background:#b6c9a21a;border:1px solid #b6c9a22b;letter-spacing:.07em;padding:7px 11px;color:#9faf91}\n.toggle-options button.active{border-color:#c9956399;background:#b2753f38;color:#e3cfaa}\n.toggle-options button:hover,.setting-buttons button:hover,.settings-actions button:hover{background:#b6c9a232}\n.settings-actions{display:flex;justify-content:flex-end;margin:7px 0 2px}\n.setting-buttons{align-items:flex-start;margin-top:10px}\n.setting-buttons>div{display:flex;gap:5px;flex-wrap:wrap;justify-content:flex-end}\n.settings-intro small{font-family:var(--title-font);font-size:9px;letter-spacing:.09em;color:#8fa181}\n'''
if '/* v0.2.1 expanded settings */' not in s:s+=append
write(p,s)

# Version/history
p='src/config/version.ts'
write(p,"""export const GAME_VERSION='0.2.1';\nexport const GAME_BUILD='EA-02.1';\nexport const GAME_RELEASE_DATE='2026-09-11';\n\nexport interface ChangeEntry {version:string;date:string;title:string;changes:string[]}\nexport const CHANGELOG:ChangeEntry[]=[\n  {version:'0.2.1',date:'2026-09-11',title:'Cross-device camera & settings patch',changes:[\n    'Kept the world FOV behaviour that is working correctly on the Windows reference build.',\n    'Added separate held-item FOV, invert Y and optional head bob controls.',\n    'Added render scale, dynamic shadow, crosshair opacity and compass controls.',\n    'Added camera reset, full settings reset and a cache-busting Reload Latest Build action.',\n    'Added the exact game version/build to developer telemetry for cross-device debugging.',\n    'Old saved settings migrate safely to the expanded settings model without touching world saves.'\n  ]},\n  {version:'0.2.0',date:'2026-09-11',title:'Reconciliation update',changes:[\n    'Merged the useful unfinished local Codex work into the GitHub build.',\n    'Restored direct, clearly visible vertical FOV control from 60° to 100°.',\n    'Kept the corrected yaw-based first-person movement so W follows the camera heading.',\n    'Improved station placement collision checks against structures, landmarks and resources.',\n    'Stations now clear grass beneath their footprint and enforce a safe world station limit.',\n    'Improved procedural landmark spacing and safer POI teleport/debug positioning.',\n    'Added smoother independent rain, fog and storm transitions plus animated station flames.',\n    'Added workbench-specific recipes and cleaner held-item behaviour for station kits.',\n    'Added automatic GitHub Pages deployment, visible versioning and this in-game history panel.'\n  ]},\n  {version:'0.1.0',date:'2026-09-08',title:'Early access foundation',changes:[\n    'Procedural island survival loop with gathering, crafting, building and local saves.',\n    'Inventory, stations, weather, map/waypoints, structures, tools and first-person viewmodel.',\n    'Performance/visual polish, diagnostics and deterministic browser QA tooling.'\n  ]}\n];\n""")

p='CHANGELOG.md'
s=read(p)
entry="""## 0.2.1 — 2026-09-11\n\nCross-device camera/settings patch.\n\n- Preserved the current world FOV behaviour that is working correctly on the Windows reference build.\n- Added held-item/viewmodel FOV, invert Y and optional head bob.\n- Added render scale, dynamic shadows, crosshair opacity and compass controls.\n- Added Reset Camera, Reset Settings and Reload Latest Build controls.\n- Added version/build identification to F3 telemetry for PC/Mac comparison.\n- Existing settings migrate to safe defaults for the new fields; world saves are untouched.\n\n"""
if '## 0.2.1' not in s:s=s.replace('# Tideland changelog\n\n','# Tideland changelog\n\n'+entry,1)
write(p,s)

# Package version only; dependencies stay untouched.
p='package.json'; data=json.loads(read(p)); data['version']='0.2.1'; write(p,json.dumps(data,indent=2)+'\n')
p='package-lock.json'; data=json.loads(read(p)); data['version']='0.2.1'; data.get('packages',{}).get('',{})['version']='0.2.1'; write(p,json.dumps(data,indent=2)+'\n')

# Encourage a fresh document on static hosting; hashed Vite assets still handle immutable JS/CSS.
p='index.html'; s=read(p)
s=replace_once(s,'<meta name="viewport" content="width=device-width,initial-scale=1.0"/>','<meta name="viewport" content="width=device-width,initial-scale=1.0"/><meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate"/><meta http-equiv="Pragma" content="no-cache"/><meta http-equiv="Expires" content="0"/>','index cache hints')
write(p,s)

# Update the settings persistence regression for the expanded, backwards-compatible model.
p='tests/simulation.test.ts'; s=read(p)
s=replace_once(s,'    expect(loadSettings()).toEqual(settings);','    expect(loadSettings()).toMatchObject(settings);\n    expect(loadSettings()).toMatchObject({viewmodelFov:50,invertY:false,headBob:false,renderScale:1,shadows:true,crosshairOpacity:1,showCompass:true});','settings regression expectation')
write(p,s)

print('Tideland v0.2.1 settings/cache patch applied')
