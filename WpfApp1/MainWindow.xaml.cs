using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //already dialled symbols
        private List<int> DialledAddress = new List<int>();
        //error message for error in dialling
        private const string ERROR_DIAL = "ERROR_DIAL";
        //message for successful dialled gate
        private const string DIALLED = "DIALLED";
        //red button value
        private const int RED_BUTTON = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handle click on symbol
        /// </summary>
        private void Symbol_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            //parse value from clicked symbol to int for better comparing with stored addresses
            var value = int.Parse(((Path)sender).Tag.ToString());
            //debug only
            Debug.WriteLine(value);
            //now counting only porting in our galaxy => only seven symbols are possible to press to dial
            if (DialledAddress.Count >= 7)
            {
                //at the end if true, we have match in correct address
                var same = false;
                //zero value is limited to red button which starts to take connection
                if (value == RED_BUTTON)
                {
                    //go through database of known address
                    foreach (var address in AddressessMilkyWay)
                    {
                        for (var i = 0; i < address.Count - 1; i++)
                        {
                            //looking only for perfect match in every symbol in an address
                            same = DialledAddress[i] == address[i];
                            //we are looking only for perfect match in every symbol
                            if (!same) break;
                        }
                        //have match, we can dial
                        if (same) break;
                    }
                }
                //for debug purpose show message if dialing was sucessful
                MessageBox.Show(!same ? ERROR_DIAL : DIALLED);
                //clear session for dialling
                DialledAddress = new List<int>();
            }
            else
            {
                //zero is limited for red button ;)
                //every symbol can be pressed only once
                if(value == RED_BUTTON || DialledAddress.Contains(value))
                    MessageBox.Show(ERROR_DIAL);
                else
                    //add pressed symbol to list of current session of dialled symbols
                    DialledAddress.Add(value);
            }
        }

        /// <summary>
        /// List of known addresses
        /// </summary>
        private static readonly List<List<int>> AddressessMilkyWay = new List<List<int>>
        {
            new List<int>{27,7,15,32,12,30},//Abydos | Children of the Gods
            new List<int>{20,18,11,38,10,32},//apophis base | Children of the Gods
            new List<int>{20,2,35,8,26,15},//camelot PX1-767 | Camelot
            new List<int>{29,3,6,9,12,16},//Castiana # sahal | The Pegasus Project
            new List<int>{29,18,19,20,21,22},//Castiana # sahal | The Pegasus Project
            new List<int>{9,2,23,15,37,20},//Chulak | Children of the Gods
            new List<int>{14,21,16,11,30,7},//clava thessara infinitas | Dominion
            new List<int>{26,20,35,32,23,4},//clava thessara infinitas | Dominion
            new List<int>{3,32,16,8,10,12},//desroyers | There... Grace of God
            new List<int>{28,26,5,36,11,29},//EArth | Soltitudes
            new List<int>{28,38,35,9,15,3},//Edor | A hundred Days
            new List<int>{30,27,9,7,18,16},//Euronda | The Other Side
            new List<int>{29,8,18,22,4,25},//Juna | Double Jeopardy
            new List<int>{6,16,8,3,26,25},//Kallana | Beachhead
            new List<int>{26,35,6,8,23,14},//Kheb | Maternal Instinct
            new List<int>{18,2,30,12,26,33},//KTau | Red Sky
            new List<int>{24,12,32,7,11,34},//MArtins homeworld | Point of No Return
            new List<int>{38,28,15,35,3,19},//Nid off world base | Shades of Grey
            new List<int>{11,27,23,16,33,3,9},//Othala | The fifth race
            new List<int>{28,8,16,33,13,31},//P2X-555 | 1969
            new List<int>{38,9,28,15,35,3},//P34-353J | The Tok'ra
            new List<int>{19,8,4,37,26,16},//P3W-451 | A Matter of Time
            new List<int>{9,26,34,37,17,21},//P3X-118 | Foothold
            new List<int>{3,28,9,35,24,15},//P3X562 | Cold Lazarus
            new List<int>{25,8,18,29,4,22},//P9C-372 | Entity
            new List<int>{12,36,23,18,7,27},//PB5-926 | Serpents Song
            new List<int>{35,3,31,29,5,17},//Praclarush Taonas | Lost City
            new List<int>{30,19,34,9,33,18},//sangreal planet | The Quest
            new List<int>{33,28,23,26,16,31},//tartarus | Evolution
            new List<int>{6,33,27,37,11,18},//tollan | Enigma
            new List<int>{4,29,8,22,18,25},//tollana | Pretense
            new List<int>{3,8,2,12,19,30},//vagon brei | Morpheus
            new List<int>{9,18,27,15,21,36}//unnamed, sg1s final destination | Unending
        };
    }
}
