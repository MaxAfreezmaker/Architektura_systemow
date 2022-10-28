using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Architektura_systemu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            index.IsChecked = true;
            reg_to_memory.IsChecked = true;

        }

        /// <summary>
        /// Stos procesora
        /// </summary>
        private Stack My_stack = new Stack();
        /// <summary>
        /// Pamieć procesora
        /// </summary>
        private string[] memory = new string[65536];
        /// <summary>
        /// Wartość wierzchołka stosu
        /// </summary>
        private int sp;
        /// <summary>
        /// Handles the 1 event of the CheckBox_change control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_change_1(object sender, RoutedEventArgs e)
        {


            if (sender.Equals(mov_box))
            {
                if (mov_box.IsChecked == true)
                {
                    xchg_box.IsChecked = false;
                }
            }
            else if (sender.Equals(xchg_box))
            {
                if (xchg_box.IsChecked == true)
                {
                    mov_box.IsChecked = false;
                }
            }


        }
        /// <summary>
        /// Ustawia losowe wartości w rejestrach
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rng = new Random();

            output_ax.Text = rng.Next(0, 15).ToString("X") + rng.Next(0, 15).ToString("X") + rng.Next(0, 15).ToString("X") + rng.Next(0, 15).ToString("X");
            output_bx.Text = rng.Next(0, 15).ToString("X") + rng.Next(0, 15).ToString("X") + rng.Next(0, 15).ToString("X") + rng.Next(0, 15).ToString("X");
            output_cx.Text = rng.Next(0, 15).ToString("X") + rng.Next(0, 15).ToString("X") + rng.Next(0, 15).ToString("X") + rng.Next(0, 15).ToString("X");
            output_dx.Text = rng.Next(0, 15).ToString("X") + rng.Next(0, 15).ToString("X") + rng.Next(0, 15).ToString("X") + rng.Next(0, 15).ToString("X");
            info_bar.Text = "/> Random rejestry - POMYŚLNIE";
        }
        /// <summary>
        /// Zeruje wartości w rejestrach
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_zero(object sender, RoutedEventArgs e)
        {
            output_ax.Text = "0000";
            output_bx.Text = "0000";
            output_cx.Text = "0000";
            output_dx.Text = "0000";
            info_bar.Text = "/> Wyzerowane rejestry - POMYŚLNIE";
        }
        /// <summary>
        /// Handles the xchg event of the Button_Click_mov control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_mov_xchg(object sender, RoutedEventArgs e)
        {
            string objname = (((Button)sender).Content).ToString();
            string left = $"{objname[0]}{objname[1]}";
            string right = $"{objname[objname.Length - 2]}{objname[objname.Length - 1]}";

            if (mov_box.IsChecked == true)
            {
                switch (left)
                {
                    case "AX":
                        switch (right)
                        {
                            case "BX":
                                {
                                    output_ax.Text = output_bx.Text;
                                    break;
                                }
                            case "CX":
                                {
                                    output_ax.Text = output_cx.Text;
                                    break;
                                }
                            case "DX":
                                {
                                    output_ax.Text = output_dx.Text;
                                    break;
                                }
                        }
                        break;
                    case "BX":
                        switch (right)
                        {
                            case "AX":
                                {
                                    output_bx.Text = output_ax.Text;
                                    break;
                                }
                            case "CX":
                                {
                                    output_bx.Text = output_cx.Text;
                                    break;
                                }
                            case "DX":
                                {
                                    output_bx.Text = output_dx.Text;
                                    break;
                                }
                        }
                        break;
                    case "CX":
                        switch (right)
                        {
                            case "AX":
                                {
                                    output_cx.Text = output_ax.Text;
                                    break;
                                }
                            case "BX":
                                {
                                    output_cx.Text = output_bx.Text;
                                    break;
                                }
                            case "DX":
                                {
                                    output_cx.Text = output_dx.Text;
                                    break;
                                }
                        }
                        break;
                    case "DX":
                        switch (right)
                        {
                            case "AX":
                                {
                                    output_dx.Text = output_ax.Text;
                                    break;
                                }
                            case "CX":
                                {
                                    output_dx.Text = output_cx.Text;
                                    break;
                                }
                            case "DX":
                                {
                                    output_dx.Text = output_dx.Text;
                                    break;
                                }
                        }
                        break;
                }
                info_bar.Text = $"/> Mov,{left}->{right} - POMYŚLNIE";
            }
            else if (xchg_box.IsChecked == true)
            {
                switch (left)
                {
                    case "AX":
                        switch (right)
                        {
                            case "BX":
                                {
                                    string _ = output_ax.Text;
                                    output_ax.Text = output_bx.Text;
                                    output_bx.Text = _;
                                    break;
                                }
                            case "CX":
                                {
                                    string _ = output_ax.Text;
                                    output_ax.Text = output_cx.Text;
                                    output_cx.Text = _;
                                    break;
                                }
                            case "DX":
                                {
                                    string _ = output_ax.Text;
                                    output_ax.Text = output_dx.Text;
                                    output_dx.Text = _;
                                    break;
                                }
                        }
                        break;
                    case "BX":
                        switch (right)
                        {
                            case "AX":
                                {
                                    string _ = output_bx.Text;
                                    output_bx.Text = output_ax.Text;
                                    output_ax.Text = _;
                                    break;
                                }
                            case "CX":
                                {
                                    string _ = output_bx.Text;
                                    output_bx.Text = output_cx.Text;
                                    output_cx.Text = _;
                                    break;
                                }
                            case "DX":
                                {
                                    string _ = output_bx.Text;
                                    output_bx.Text = output_dx.Text;
                                    output_dx.Text = _;
                                    break;
                                }
                        }
                        break;
                    case "CX":
                        switch (right)
                        {
                            case "AX":
                                {
                                    string _ = output_cx.Text;
                                    output_cx.Text = output_ax.Text;
                                    output_ax.Text = _;
                                    break;
                                }
                            case "BX":
                                {
                                    string _ = output_cx.Text;
                                    output_cx.Text = output_bx.Text;
                                    output_bx.Text = _;
                                    break;
                                }
                            case "DX":
                                {
                                    string _ = output_cx.Text;
                                    output_cx.Text = output_dx.Text;
                                    output_dx.Text = _;
                                    break;
                                }
                        }
                        break;
                    case "DX":
                        switch (right)
                        {
                            case "AX":
                                {
                                    string _ = output_dx.Text;
                                    output_dx.Text = output_ax.Text;
                                    output_ax.Text = _;
                                    break;
                                }
                            case "CX":
                                {
                                    string _ = output_dx.Text;
                                    output_dx.Text = output_cx.Text;
                                    output_cx.Text = _;
                                    break;
                                }
                            case "BX":
                                {
                                    string _ = output_dx.Text;
                                    output_dx.Text = output_bx.Text;
                                    output_bx.Text = _;
                                    break;
                                }
                        }
                        break;
                }
                info_bar.Text = $"/> XCHG,{left}->{right} - POMYŚLNIE";
            }
            else
            {
                info_bar.Text = "/> Nie wybrano 'Mov' lub 'Xchg' ";
            }
        }


        /// <summary>
        /// Handles the 1 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            if (reg_to_memory.IsChecked == true)
            {
                memory_to_reg.IsChecked = false;
            }

        }

        /// <summary>
        /// Handles the 2 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {
            if (memory_to_reg.IsChecked == true)
            {
                reg_to_memory.IsChecked = false;
            }
        }

        /// <summary>
        /// Handles the 3 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_3(object sender, RoutedEventArgs e)
        {
            if (index.IsChecked == true)
            {
                index_.Visibility = Visibility;
                border_index_.Visibility = Visibility;

                base_.Visibility = Visibility.Hidden;
                border_base_.Visibility = Visibility.Hidden;

                index_base_.Visibility = Visibility.Hidden;
                border_index_base_.Visibility = Visibility.Hidden;

                based.IsChecked = false;
                index_based.IsChecked = false;

                alway.Visibility = Visibility;
                border_alway.Visibility = Visibility;

                border_reg.BorderBrush = Brushes.White;
            }
        }

        /// <summary>
        /// Handles the 4 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_4(object sender, RoutedEventArgs e)
        {
            if (based.IsChecked == true)
            {
                base_.Visibility = Visibility;
                border_base_.Visibility = Visibility;

                index_.Visibility = Visibility.Hidden;
                border_index_.Visibility = Visibility.Hidden;

                index_base_.Visibility = Visibility.Hidden;
                border_index_base_.Visibility = Visibility.Hidden;

                index.IsChecked = false;
                index_based.IsChecked = false;

                alway.Visibility = Visibility;
                border_alway.Visibility = Visibility;

                border_reg.BorderBrush = Brushes.White;
            }
        }

        /// <summary>
        /// Handles the 5 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_5(object sender, RoutedEventArgs e)
        {
            if (index_based.IsChecked == true)
            {
                border_index_base_.Visibility = Visibility;
                index_base_.Visibility = Visibility;

                base_.Visibility = Visibility.Hidden;
                border_base_.Visibility = Visibility.Hidden;

                index_.Visibility = Visibility.Hidden;
                border_index_.Visibility = Visibility.Hidden;

                based.IsChecked = false;
                index.IsChecked = false;

                alway.Visibility = Visibility;
                border_alway.Visibility = Visibility;

                border_reg.BorderBrush = Brushes.White;
            }
        }


        /// <summary>
        /// Handles the 6 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_6(object sender, RoutedEventArgs e)
        {
            if (si_.IsChecked == true)
            {
                di_.IsChecked = false;
            }
        }

        /// <summary>
        /// Handles the 7 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_7(object sender, RoutedEventArgs e)
        {
            if (di_.IsChecked == true)
            {
                si_.IsChecked = false;
            }
        }

        /// <summary>
        /// Handles the 8 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_8(object sender, RoutedEventArgs e)
        {
            if (bx_.IsChecked == true)
            {
                bp_.IsChecked = false;
            }
        }

        /// <summary>
        /// Handles the 9 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_9(object sender, RoutedEventArgs e)
        {
            if (bp_.IsChecked == true)
            {
                bx_.IsChecked = false;
            }
        }
        /// <summary>
        /// Chowa obramowanie i wybór zapisu
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Index_Unchecked(object sender, RoutedEventArgs e)
        {
            if (index.IsChecked == false && based.IsChecked == false && index_based.IsChecked == false)
            {
                index_base_.Visibility = Visibility.Hidden;
                base_.Visibility = Visibility.Hidden;
                index_.Visibility = Visibility.Hidden;
                alway.Visibility = Visibility.Hidden;
                border_alway.Visibility = Visibility.Hidden;
                border_index_.Visibility = Visibility.Hidden;
                border_base_.Visibility = Visibility.Hidden;
                border_index_base_.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Handles the 10 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_10(object sender, RoutedEventArgs e)
        {
            if (sibx_mem.IsChecked == true)
            {
                dibp_mem.IsChecked = false;
                dibx_mem.IsChecked = false;
                sibp_mem.IsChecked = false;
            }
        }

        /// <summary>
        /// Handles the 11 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_11(object sender, RoutedEventArgs e)
        {
            if (dibx_mem.IsChecked == true)
            {
                dibp_mem.IsChecked = false;
                sibx_mem.IsChecked = false;
                sibp_mem.IsChecked = false;
            }
        }

        /// <summary>
        /// Handles the 12 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_12(object sender, RoutedEventArgs e)
        {
            if (sibp_mem.IsChecked == true)
            {
                dibp_mem.IsChecked = false;
                dibx_mem.IsChecked = false;
                sibx_mem.IsChecked = false;
            }
        }

        /// <summary>
        /// Handles the 13 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_13(object sender, RoutedEventArgs e)
        {
            if (dibp_mem.IsChecked == true)
            {
                sibx_mem.IsChecked = false;
                dibx_mem.IsChecked = false;
                sibp_mem.IsChecked = false;
            }
        }

        /// <summary>
        /// Handles the 14 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_14(object sender, RoutedEventArgs e)
        {
            if (ax_mem.IsChecked == true)
            {
                bx_mem.IsChecked = false;
                dx_mem.IsChecked = false;
                cx_mem.IsChecked = false;
            }
        }

        /// <summary>
        /// Handles the 15 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_15(object sender, RoutedEventArgs e)
        {
            if (bx_mem.IsChecked == true)
            {
                ax_mem.IsChecked = false;
                dx_mem.IsChecked = false;
                cx_mem.IsChecked = false;
            }
        }

        /// <summary>
        /// Handles the 16 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_16(object sender, RoutedEventArgs e)
        {
            if (cx_mem.IsChecked == true)
            {
                bx_mem.IsChecked = false;
                dx_mem.IsChecked = false;
                ax_mem.IsChecked = false;
            }
        }

        /// <summary>
        /// Handles the 17 event of the CheckBox_Checked control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CheckBox_Checked_17(object sender, RoutedEventArgs e)
        {
            if (dx_mem.IsChecked == true)
            {
                bx_mem.IsChecked = false;
                ax_mem.IsChecked = false;
                cx_mem.IsChecked = false;
            }
        }
        /// <summary>
        /// Sprawdza czy dane wejściowe spełniają warunek i zawierają poprawne znaki
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>
        /// string
        /// </returns>
        /// <remarks>
        /// Zwraca ciąg 4 znaków jeśli są zgodne z hex lub # jeśli nie
        /// </remarks>
        private string Input_check(string input)
        {
            var y = input.ToCharArray();
            char[] test = { 'A', 'B', 'C', 'D', 'E', 'F', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool error = true;

            for (int i = 0; i < input.Length; i++)
            {
                bool min_error = true;
                for (int j = 0; j < test.Length; j++)
                {
                    if (y[i] == test[j])
                    {
                        min_error = false;
                    }
                }
                if (min_error == false) { error = false; } else { error = true; break; }
            }
            if (error == false)
            {
                if (input.Length == 4)
                {
                    return input.ToUpper();
                }
                else if (input.Length == 3)
                {
                    return y[0].ToString() + y[1].ToString() + y[2].ToString() + "0";
                }
                else if (input.Length == 2)
                {
                    return y[0].ToString() + y[1].ToString() + "00";
                }
                else if (input.Length == 1)
                {
                    return y[0].ToString() + "000";
                }
            }
            return "#";
        }
        /// <summary>
        /// Handles the KeyDown event of the Input_ax control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void Input_ax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string x = input_ax.Text.ToUpper();
                if (Input_check(x) != "#")
                {
                    output_ax.Text = Input_check(x);
                    info_bar.Text = "/> AX Wprowadzono - POMYŚLNIE";
                }
                else
                {
                    info_bar.Text = "/> AX Wprowadzono - NIE POMYŚLNIE";
                }
                input_ax.Text = "";

            }
        }

        /// <summary>
        /// Handles the KeyDown event of the Input_bx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void Input_bx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string x = input_bx.Text.ToUpper();
                if (Input_check(x) != "#")
                {
                    output_bx.Text = Input_check(x);
                    info_bar.Text = "/> BX Wprowadzono - POMYŚLNIE";
                }
                else
                {
                    info_bar.Text = "/> BX Wprowadzono - NIE POMYŚLNIE";
                }
                input_bx.Text = "";

            }

        }

        /// <summary>
        /// Handles the KeyDown event of the Input_cx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void Input_cx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string x = input_cx.Text.ToUpper();
                if (Input_check(x) != "#")
                {
                    output_cx.Text = Input_check(x);
                    info_bar.Text = "/> CX Wprowadzono - POMYŚLNIE";
                }
                else
                {
                    info_bar.Text = "/> CX Wprowadzono - NIE POMYŚLNIE";
                }
                input_cx.Text = "";

            }
        }

        /// <summary>
        /// Handles the KeyDown event of the Input_dx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void Input_dx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string x = input_dx.Text.ToUpper();
                if (Input_check(x) != "#")
                {
                    output_dx.Text = Input_check(x);
                    info_bar.Text = "/> DX Wprowadzono - POMYŚLNIE";
                }
                else
                {
                    info_bar.Text = "/> DX Wprowadzono - NIE POMYŚLNIE";
                }
                input_dx.Text = "";

            }

        }

        /// <summary>
        /// Handles the KeyDown event of the Input_disp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void Input_disp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string x = input_disp.Text.ToUpper();
                if (Input_check(x) != "#")
                {
                    disp_output.Text = Input_check(x);
                    info_bar.Text = "/> DISP Wprowadzono - POMYŚLNIE";
                }
                else
                {
                    info_bar.Text = "/> DISP Wprowadzono - NIE POMYŚLNIE";
                }
                input_disp.Text = "";

            }
        }
        /// <summary>
        /// Zwraca numer indexu
        /// </summary>
        /// <param name="si">int</param>
        /// <param name="di">int</param>
        /// <param name="disp">int</param>
        /// <param name="bp">int</param>
        /// <param name="bx">int</param>
        /// <returns>
        /// int
        /// </returns>
        /// <remarks>
        /// Zwraca sume odpowiednich rejestrów tworzących numer indexu do pamięci
        /// </remarks>
        public int Count_index(int si, int di, int disp, int bp, int bx)
        {
            if (si_.IsChecked == true)
            {
                return si + disp;
            }
            else if (di_.IsChecked == true)
            {
                return di + disp;
            }
            else if (bx_.IsChecked == true)
            {
                return bx + disp;
            }
            else if (bp_.IsChecked == true)
            {
                return bp + disp;
            }
            else if (sibx_mem.IsChecked == true)
            {
                return si + disp + bx;
            }
            else if (dibx_mem.IsChecked == true)
            {
                return di + disp + bx;
            }
            else if (sibp_mem.IsChecked == true)
            {
                return si + disp + bp;
            }
            else if (dibp_mem.IsChecked == true)
            {
                return di + disp + bp;
            }
            else
            {
                return -1;
            }
        }
        /// <summary>
        /// Sprawdza czy nie przekracza zakresu tablicy
        /// </summary>
        /// <param name="index">int</param>
        /// <returns>
        /// int
        /// </returns>
        /// <exception cref="System.ArgumentException">Kiedy przekroczymy tablice 'memory' [65536]</exception>

        public int Lenght_test(int index)
        {
            if (index < memory.Length)
            {
                return index;
            }
            else
            {
                throw new ArgumentException("Index is out of range", nameof(index));
            }
        }

        /// <summary>
        /// Handles the Click event of the Mov_mem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Mov_mem_Click(object sender, RoutedEventArgs e)
        {
            int si = Convert.ToInt32(si_output.Text, 16);
            int di = Convert.ToInt32(di_output.Text, 16);
            int disp = Convert.ToInt32(disp_output.Text, 16);
            int bp = Convert.ToInt32(bp_output.Text, 16);
            int bxx = Convert.ToInt32(output_bx.Text, 16);


            if (reg_to_memory.IsChecked == true)
            {
                try
                {
                    Input_memory(Lenght_test(Count_index(si, di, disp, bp, bxx)));
                }
                catch (ArgumentException)
                {
                    info_bar.Text = "/> Index przekracza zakres !!";
                }
            }
            else if (memory_to_reg.IsChecked == true)
            {
                try
                {
                    Output_memory(Lenght_test(Count_index(si, di, disp, bp, bxx)));
                }
                catch (ArgumentException)
                {
                    info_bar.Text = "/> Index przekracza zakres !!";
                }
            }
        }
        /// <summary>
        /// Handles the Click event of the Xchg_mem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Xchg_mem_Click(object sender, RoutedEventArgs e)
        {
            int si = Convert.ToInt32(si_output.Text, 16);
            int di = Convert.ToInt32(di_output.Text, 16);
            int disp = Convert.ToInt32(disp_output.Text, 16);
            int bp = Convert.ToInt32(bp_output.Text, 16);
            int bxx = Convert.ToInt32(output_bx.Text, 16);

            string ax = output_ax.Text;
            string bx = output_bx.Text;
            string cx = output_cx.Text;
            string dx = output_dx.Text;
            try
            {
                Output_memory(Lenght_test(Count_index(si, di, disp, bp, bxx)));
                Input_memory(Lenght_test(Count_index(si, di, disp, bp, bxx)), ax, bx, cx, dx);
            }
            catch (ArgumentException)
            {
                info_bar.Text = "/> Index przekracza zakres !!";
            }

        }
        /// <summary>
        /// Handles the KeyDown event of the Input_si control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void Input_si_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string x = input_si.Text.ToUpper();
                if (Input_check(x) != "#")
                {
                    si_output.Text = Input_check(x);
                    info_bar.Text = "/> SI Wprowadzono - POMYŚLNIE";
                }
                else
                {
                    info_bar.Text = "/> SI Wprowadzono - NIE POMYŚLNIE";
                }
                input_si.Text = "";
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the Input_di control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void Input_di_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string x = input_di.Text.ToUpper();
                if (Input_check(x) != "#")
                {
                    di_output.Text = Input_check(x);
                    info_bar.Text = "/> DI Wprowadzono - POMYŚLNIE";
                }
                else
                {
                    info_bar.Text = "/> DI Wprowadzono - NIE POMYŚLNIE";
                }
                input_di.Text = "";
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the Input_bp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void Input_bp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string x = input_bp.Text.ToUpper();
                if (Input_check(x) != "#")
                {
                    bp_output.Text = Input_check(x);
                    info_bar.Text = "/> BP Wprowadzono - POMYŚLNIE";
                }
                else
                {
                    info_bar.Text = "/> BP Wprowadzono - NIE POMYŚLNIE";
                }
                input_bp.Text = "";
            }
        }

        /// <summary>
        /// umieszcza dane do tablicy(memory)
        /// </summary>
        /// <param name="index_num">int</param>
        /// <param name="ax">string</param>
        /// <param name="bx">string</param>
        /// <param name="cx">string</param>
        /// <param name="dx">string</param>
        private void Input_memory(int index_num, string ax = "", string bx = "", string cx = "", string dx = "")
        {
            if (index_num == -1)
            {
                info_bar.Text = "/> Nie wybrano sposobu liczenia indexu ";
            }
            else
            {
                if (index.IsChecked == true || based.IsChecked == true || index_based.IsChecked == true)
                {
                    if (ax_mem.IsChecked == true)
                    {
                        memory[index_num] = (ax != "") ? ax : output_ax.Text;
                        info_bar.Text = $"/> AX -> Memory[{index_num}] - POMYŚLNIE";
                    }
                    else if (bx_mem.IsChecked == true)
                    {
                        memory[index_num] = (bx != "") ? bx : output_bx.Text;
                        info_bar.Text = $"/> BX -> Memory[{index_num}] - POMYŚLNIE";
                    }
                    else if (cx_mem.IsChecked == true)
                    {
                        memory[index_num] = (cx != "") ? cx : output_cx.Text;
                        info_bar.Text = $"/> CX -> Memory[{index_num}] - POMYŚLNIE";
                    }
                    else if (dx_mem.IsChecked == true)
                    {
                        memory[index_num] = (dx != "") ? dx : output_dx.Text;
                        info_bar.Text = $"/> DX -> Memory[{index_num}] - POMYŚLNIE";
                    }
                    else
                    {
                        info_bar.Text = "/> Nie wybrano miejsca docelowego";
                    }
                }
                else
                {
                    info_bar.Text = "/> Nie wybrano sposobu liczenia indexu ";
                }
            }
        }
        /// <summary>
        /// Wyszukuje z pamieci zawartośc i wyswietla w rejestrach
        /// </summary>
        /// <param name="index_num">int</param>
        private void Output_memory(int index_num)
        {
            if (index_num == -1)
            {
                info_bar.Text = "/> Nie wybrano sposobu liczenia indexu ";
            }
            else
            {
                if (memory[index_num] == null) { memory[index_num] = "0000"; }
                if (index.IsChecked == true || based.IsChecked == true || index_based.IsChecked == true)
                {
                    if (ax_mem.IsChecked == true)
                    {
                        output_ax.Text = memory[index_num];
                        info_bar.Text = $"/> Memory[{index_num}] -> AX  - POMYŚLNIE";
                    }
                    else if (bx_mem.IsChecked == true)
                    {
                        output_bx.Text = memory[index_num];
                        info_bar.Text = $"/> Memory[{index_num}] -> BX  - POMYŚLNIE";
                    }
                    else if (cx_mem.IsChecked == true)
                    {
                        output_cx.Text = memory[index_num];
                        info_bar.Text = $"/> Memory[{index_num}] -> CX  - POMYŚLNIE";
                    }
                    else if (dx_mem.IsChecked == true)
                    {
                        output_dx.Text = memory[index_num];
                        info_bar.Text = $"/> Memory[{index_num}] -> DX  - POMYŚLNIE";
                    }
                    else
                    {
                        info_bar.Text = "/> Nie wybrano miejsca docelowego";
                    }
                }
                else
                {
                    info_bar.Text = "/> Nie wybrano sposobu liczenia indexu";
                }
            }
        }
        /// <summary>
        /// Handles the Click event of the Push_ax control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Push_ax_Click(object sender, RoutedEventArgs e)
        {
            string ax = output_ax.Text;
            My_stack.Push(ax);
            sp += 2;
            Sp_update();
            info_bar.Text = "/> Push AX - POMYŚLNIE";
        }
        /// <summary>
        /// Handles the Click event of the push_bx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void push_bx_Click(object sender, RoutedEventArgs e)
        {
            string bx = output_bx.Text;
            My_stack.Push(bx);
            sp += 2;
            Sp_update();
            info_bar.Text = "/> Push BX - POMYŚLNIE";
        }

        /// <summary>
        /// Handles the Click event of the push_cx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void push_cx_Click(object sender, RoutedEventArgs e)
        {
            string cx = output_cx.Text;
            My_stack.Push(cx);
            sp += 2;
            Sp_update();
            info_bar.Text = "/> Push CX - POMYŚLNIE";
        }

        /// <summary>
        /// Handles the Click event of the push_dx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void push_dx_Click(object sender, RoutedEventArgs e)
        {
            string dx = output_dx.Text;
            My_stack.Push(dx);
            sp += 2;
            Sp_update();
            info_bar.Text = "/> Push DX - POMYŚLNIE";
        }

        /// <summary>
        /// Handles the Click event of the pop_ax control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void pop_ax_Click(object sender, RoutedEventArgs e)
        {
            if (sp - 2 < 0)
            {
                info_bar.Text = "/> Brak danych na stosie";
            }
            else
            {
                sp -= 2;
                string ax = My_stack.Pop().ToString();
                output_ax.Text = ax;
                info_bar.Text = "/> POP AX - POMYŚLNIE";
                Sp_update();
            }
        }

        /// <summary>
        /// Handles the Click event of the pop_bx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void pop_bx_Click(object sender, RoutedEventArgs e)
        {
            if (sp - 2 < 0)
            {
                info_bar.Text = "/> Brak danych na stosie";
            }
            else
            {
                sp -= 2;
                string bx = My_stack.Pop().ToString();
                output_bx.Text = bx;
                info_bar.Text = "/> POP BX - POMYŚLNIE";
                Sp_update();
            }
        }

        /// <summary>
        /// Handles the Click event of the pop_cx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void pop_cx_Click(object sender, RoutedEventArgs e)
        {
            if (sp - 2 < 0)
            {
                info_bar.Text = "/> Brak danych na stosie";
            }
            else
            {
                sp -= 2;
                string cx = My_stack.Pop().ToString();
                output_cx.Text = cx;
                info_bar.Text = "/> POP CX - POMYŚLNIE";
                Sp_update();
            }
        }

        /// <summary>
        /// Handles the Click event of the pop_dx control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void pop_dx_Click(object sender, RoutedEventArgs e)
        {
            if (sp - 2 < 0)
            {
                info_bar.Text = "/> Brak danych na stosie";
            }
            else
            {
                sp -= 2;
                string dx = My_stack.Pop().ToString();
                output_dx.Text = dx;
                info_bar.Text = "/> POP DX - POMYŚLNIE";
                Sp_update();
            }
        }
        /// <summary>
        /// Odświeża sp_output
        /// </summary>
        /// <remarks>
        /// Zamienia sp na Hex i zależnie od długości dodaje zera do łącznej długości 4
        /// </remarks>
        private void Sp_update()
        {
            string hexValue = sp.ToString("X");
            int dlugosc = (hexValue).ToString().Length;
            if (dlugosc == 1)
            {
                sp_output.Text = Input_check($"000{hexValue}");
            }
            else if (dlugosc == 2)
            {
                sp_output.Text = Input_check($"00{hexValue}");
            }
            else if (dlugosc == 3)
            {
                sp_output.Text = Input_check($"0{hexValue}");
            }
            else if (dlugosc == 4)
            {
                sp_output.Text = Input_check($"{hexValue}");
            }
        }
    }
}