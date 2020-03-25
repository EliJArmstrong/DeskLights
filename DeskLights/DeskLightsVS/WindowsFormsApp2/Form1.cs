// <author>Eli Armstrong</author>
// <file>Form1.cs</file>
// <date>2018-07-26</date>
// <summary> This program is the UI for my desk lights above my desk. This 
// program check the status from an Arduino and sends a receives serial data.
// but this is just a complicated program to turn off and on the lights above my 
// desk</summary> 
// <copyright>2018 Eli Armstrong</copyright>

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
// using System.Diagnostics; only needed for debuging.
using System.IO;
using System.Linq;

namespace DeskLights
{
    // ------------------------------------------------------------------------------------------------------
    //       ___                        ___            ___                  ___        ___                  
    //      (   )                      (   )          (   )  .-.           (   )      (   )                 
    //    .-.| |    .--.       .--.     | |   ___      | |  ( __)   .--.    | | .-.    | |_         .--.    
    //   /   \ |   /    \    /  _  \    | |  (   )     | |  (''")  /    \   | |/   \  (   __)     /  _  \   
    //  |  .-. |  |  .-. ;  . .' `. ;   | |  ' /       | |   | |  ;  ,-. '  |  .-. .   | |       . .' `. ;  
    //  | |  | |  |  | | |  | '   | |   | |,' /        | |   | |  | |  | |  | |  | |   | | ___   | '   | |  
    //  | |  | |  |  |/  |  _\_`.(___)  | .  '.        | |   | |  | |  | |  | |  | |   | |(   )  _\_`.(___) 
    //  | |  | |  |  ' _.' (   ). '.    | | `. \       | |   | |  | |  | |  | |  | |   | | | |  (   ). '.   
    //  | '  | |  |  .'.-.  | |  `\ |   | |   \ \      | |   | |  | '  | |  | |  | |   | ' | |   | |  `\ |  
    //  ' `-'  /  '  `-' /  ; '._,' '   | |    \ .     | |   | |  '  `-' |  | |  | |   ' `-' ;   ; '._,' '  
    //   `.__,'    `.__.'    '.___.'   (___ ) (___)   (___) (___)  `.__. | (___)(___)   `.__.     '.___.'   
    //                                                             ( `-' ;                                  
    //                                                              `.__.                                   
    //                                                                   
    // ------------------------------------------------------------------------------------------------------

    public partial class DeskLights : Form
    {
        // -----------------------------------------------------------------------------------------
        //     ________                   _    __           _       __    __         
        //    / ____/ /___ ___________   | |  / /___ ______(_)___ _/ /_  / /__  _____
        //   / /   / / __ `/ ___/ ___/   | | / / __ `/ ___/ / __ `/ __ \/ / _ \/ ___/
        //  / /___/ / /_/ (__  |__  )    | |/ / /_/ / /  / / /_/ / /_/ / /  __(__  ) 
        //  \____/_/\__,_/____/____/     |___/\__,_/_/  /_/\__,_/_.___/_/\___/____/  
        //                                                                           
        // -----------------------------------------------------------------------------------------
        int light1Status; // This variable checks for the status for light one.
        int light2Status; // This variable checks for the status for light two.
        int light3Status; // This variable checks for the status for light 3.

        string[] portNumbers; // This will store the available ports to connect to the Arduino(s).


        // -----------------------------------------------------------------------------------------
        //      ____        __    ___         ____       ____            ____     
        //     / __ \__  __/ /_  / (_)____   / __ \___  / __/___ ___  __/ / /_    
        //    / /_/ / / / / __ \/ / / ___/  / / / / _ \/ /_/ __ `/ / / / / __/    
        //   / ____/ /_/ / /_/ / / / /__   / /_/ /  __/ __/ /_/ / /_/ / / /_      
        //  /_/____\\_,_/_.___/_/_/\__\\  /_____/\___/_/  \\_,_/\__,_/_/\__/      
        //    / ____/___  ____  _____/ /________  _______/ /_____  _____          
        //   / /   / __ \/ __ \/ ___/ __/ ___/ / / / ___/ __/ __ \/ ___/          
        //  / /___/ /_/ / / / (__  ) /_/ /  / /_/ / /__/ /_/ /_/ / /              
        //  \____/\____/_/ /_/____/\__/_/   \__,_/\___/\__/\____/_/               
        //                                                                        
        // -----------------------------------------------------------------------------------------
        public DeskLights(){
            InitializeComponent();
            port.DataReceived += Port_DataReceived;  // Sets ups the Port_DataReceived
            portNumbers = SerialPort.GetPortNames(); // This gets the available ports and stores ports. 
            comboBox1.Items.AddRange(portNumbers); // Places the available ports in the comboBox in UI.

            if (File.Exists("DeskLights.txt") && portNumbers.Contains(File.ReadAllText("DeskLights.txt")))
            {
                port.Close();
                port.PortName = File.ReadAllText("DeskLights.txt");
                port.Open();
                GetStatus();
                comboBox1.Text = port.PortName;
            }
            else
            {
                comboBox1.Text = "Select COM Port";
            }
        }


        // -----------------------------------------------------------------------------------------
        //      ____        __  __                 __  ______
        //     / __ )__  __/ /_/ /_____  ____     / / / /  _/
        //    / __  / / / / __/ __/ __ \/ __ \   / / / // /  
        //   / /_/ / /_/ / /_/ /_/ /_/ / / / /  / /_/ // /   
        //  /_____/\__,_/\__/\__/\____/_/ /_/   \____/___/   
        //      __  ___     __  __              __           
        //     /  |/  /__  / /_/ /_  ____  ____/ /____       
        //    / /|_/ / _ \/ __/ __ \/ __ \/ __  / ___/       
        //   / /  / /  __/ /_/ / / / /_/ / /_/ (__  )        
        //  /_/  /_/\___/\__/_/ /_/\____/\__,_/____/         
        //                                                   
        // -----------------------------------------------------------------------------------------

        // -----------------------------------------------------------------------------------------
        // When the light 1 button is clicked. This method will send the string of "1" to the 
        // Arduino to be processed by the Arduino and will turn on or off the light based on it's 
        // current status.
        // -----------------------------------------------------------------------------------------
        private void Light1Button_Click(object sender, EventArgs e){
            if (port.IsOpen) { port.Write("1"); }
        }

        // -----------------------------------------------------------------------------------------
        // When the light 2 button is clicked. This method will send the string of "2" to the 
        // Arduino to be processed by the Arduino and will turn on or off the light based on it's 
        // current status.
        // -----------------------------------------------------------------------------------------
        private void Light2Button_Click(object sender, EventArgs e){
            if (port.IsOpen) { port.Write("2"); }
        }

        // -----------------------------------------------------------------------------------------
        // When the light 3 button is clicked. This method will send the string of "3" to the 
        // Arduino to be processed by the Arduino and will turn on or off the light based on it's 
        // current status.
        // -----------------------------------------------------------------------------------------
        private void Light3Button_Click(object sender, EventArgs e){
            if (port.IsOpen) { port.Write("3"); }
        }

        // -----------------------------------------------------------------------------------------
        // When the on button is clicked. This method will send the string of "on" to the 
        // Arduino to be processed by the Arduino and will turn on the all the lights.
        // -----------------------------------------------------------------------------------------
        private void OnButton_Click(object sender, EventArgs e){
            if (port.IsOpen) { port.Write("n"); }
        }

        // -----------------------------------------------------------------------------------------
        // When the off button is clicked. This method will send the string of "off" to the 
        // Arduino to be processed by the Arduino and will turn off the all the lights.
        // -----------------------------------------------------------------------------------------
        private void OffButton_Click(object sender, EventArgs e){
            if (port.IsOpen) { port.Write("f"); }
        }


        // -----------------------------------------------------------------------------------------
        //     _____ __        __                __  __          __      __     
        //    / ___// /_____ _/ /___  _______   / / / /___  ____/ /___ _/ /____ 
        //    \__ \/ __/ __ `/ __/ / / / ___/  / / / / __ \/ __  / __ `/ __/ _ \
        //   ___/ / /_/ /_/ / /_/ /_/ (__  )  / /_/ / /_/ / /_/ / /_/ / /_/  __/
        //  /_____\______,_/___/___,_/____/   \____/ .___/\__,_/\__,_/\__/\___/ 
        //     /  |/  /__  / /_/ /_  ____  ____/ ////_                          
        //    / /|_/ / _ \/ __/ __ \/ __ \/ __  / ___/                          
        //   / /  / /  __/ /_/ / / / /_/ / /_/ (__  )                           
        //  /_/  /_/\___/\__/_/ /_/\____/\__,_/____/                            
        //                                                                      
        // -----------------------------------------------------------------------------------------


        // -----------------------------------------------------------------------------------------
        // This method is called automatically when a signal is passed into the serial port from 
        // the Arduino. When a change to the lights happen on the Arduino side, the Arduino will 
        // send the updated status of the light to this method to update the variables and UI 
        // buttons.
        // -----------------------------------------------------------------------------------------
        private void Port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e){
            ReceiveStatus();
            UpdateUI();
        }

        // -----------------------------------------------------------------------------------------
        // This method sends the string "info" to the Arduino board. The Arduino gets the status 
        // of the lights either on or off and sends the status of the lights back to this program. 
        // This method use the data from the Arduino and update the light status variables.
        // -----------------------------------------------------------------------------------------
        private void GetStatus(){
            port.Write("i");
            ReceiveStatus();
            UpdateUI();
        }

        // -----------------------------------------------------------------------------------------
        // This method reads Byte information (AKA integers) from the serial connection. This 
        // information is passed from Arduino. The Arduino will send 3 bytes from the first to the 
        // third's lights status.
        // -----------------------------------------------------------------------------------------
        private void ReceiveStatus(){
            if (port.BytesToRead > 0){ // checks if there is any bytes in the buffer.
                light1Status = port.ReadByte();
                light2Status = port.ReadByte();
                light3Status = port.ReadByte();
                ///Debug.WriteLine(light1Status);
                ///Debug.WriteLine(light2Status);
                // Debug.WriteLine(light3Status);
            }
        }

        // -----------------------------------------------------------------------------------------
        // This method is to be called after any get status function to update the UI based on what 
        // the Arduino status of each light.
        // -----------------------------------------------------------------------------------------
        private void UpdateUI(){
            Light1Button.BackColor = (light1Status == 0) ? Color.DarkGray : Color.WhiteSmoke;
            Light2Button.BackColor = (light2Status == 0) ? Color.DarkGray : Color.WhiteSmoke;
            Light3Button.BackColor = (light3Status == 0) ? Color.DarkGray : Color.WhiteSmoke;
        }


        // -----------------------------------------------------------------------------------------
        // This method switches the com port from the combo box.
        // -----------------------------------------------------------------------------------------
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            port.Close();
            port.PortName = comboBox1.SelectedItem.ToString();
            port.Open();
            GetStatus();
            File.WriteAllText("DeskLights.txt", comboBox1.SelectedItem.ToString());
        }
    }

    // -----------------------------------------------------------------------------------------
    //                        _____  _____    ____  ____                       
    //                       / __/ |/ / _ \  / __ \/ __/                       
    //                      / _//    / // / / /_/ / _/                         
    //                     /___/_/|_/____/__\____/_/   ___________ ____________
    //                       / _ \/ __/ __/ //_/ / /  /  _/ ___/ // /_  __/ __/
    //                      / // / _/_\ \/ ,<   / /___/ // (_ / _  / / / _\ \  
    //                     /____/___/___/_/|_| /____/___/\___/_//_/ /_/ /___/  
    //                                                      
    // -----------------------------------------------------------------------------------------
}
