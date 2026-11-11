private void Button_Click(object sender, RoutedEventArgs e) {
  int cislo;
  if (int.TryParse(txtVstup.Text, out cislo)) {
    // úspěšný převod
    txtVystup.Text = $"Dvojnasobek {2 * cislo}";
  } else {
    // neúspěšný převod
    txtVystup.Text = $"Neplatný vstup";
  }
  
}
