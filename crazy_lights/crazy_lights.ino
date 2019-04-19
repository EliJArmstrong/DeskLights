/*
 * Desk Lights: This will take in data from the serial port or from an 
 * IR remote. This program is to control the lights above my desk. 
 * Copyright 2018 Eli Armstrong
 */

// ==========================================================================
//     ____         __        __       __  __   _ __                _       
//    /  _/__  ____/ /_ _____/ /__ ___/ / / /  (_) /  _______ _____(_)__ ___
//   _/ // _ \/ __/ / // / _  / -_) _  / / /__/ / _ \/ __/ _ `/ __/ / -_|_-<
//  /___/_//_/\__/_/\_,_/\_,_/\__/\_,_/ /____/_/_.__/_/  \_,_/_/ /_/\__/___/
//                                                                          
// You can find the IR here library https://github.com/z3t0/Arduino-IRremote 
// Thank you Ken Shirriff the other contributors for the library. 
// ==========================================================================
#include <IRremote.h> 

// ====================================================
//         __   _      __   __    _______           
//        / /  (_)__ _/ /  / /_  / ___/ /__ ____ ___
//       / /__/ / _ `/ _ \/ __/ / /__/ / _ `(_-<(_-<
//      /____/_/\_, /_//_/\__/  \___/_/\_,_/___/___/
//             /___/                               
//
// This class hold the attributes of the a light  that 
// is controled by an arduino.
// ====================================================
class Light{
  public:
    // This variable holds status of the light 
    // false for off and true for on.
    bool lightStatus = false;

    // This variable hold the pin number of pin 
    // on the Arduino board.
    int pinNumber = -1;

    // This is an overloaded constructor that sets
    // the status of the light and the pin number. 
    // of the board for the light.
    Light(bool stat, int pin){
      lightStatus = stat;
      pinNumber   = pin;
    }

    // This function will changes the current on 
    // the lights pin to on/off based what is passed
    // to the function. False for off and true for on.
    void changeStatus(bool newStatus){
      if(newStatus == false){
        lightStatus = newStatus;
        digitalWrite(pinNumber, HIGH);
      } else{
        lightStatus = newStatus;
        digitalWrite(pinNumber, LOW);
      }
    }
};

// ====================================================
//             _______    _____        __      
//            /  _/ _ \  / ___/__  ___/ /__ ___
//           _/ // , _/ / /__/ _ \/ _  / -_|_-<
//          /___/_/|_|  \___/\___/\_,_/\__/___/
//                                     
// These codes are dependent on the IR remote used and
// will need to be changed based on the buttons you 
// want to do a action. To figure out what code is sent
// out when a button is pressed load the IRrecvDemo 
// from the IRremote library and change the line that 
// states "Serial.println(results.value, HEX);" to
// "Serial.println(results.value);" to get the code 
// that will work this this program.
// ==================================================== 
const int32_t LINE_CODE         = 16726215; // Turn on and off the lights in a row.
const int32_t ALL_ON_CODE       = 16736925; // Turns on all of  the lights.
const int32_t ALL_OFF_CODE      = 16754775; // Turns off all of the lights.
const int32_t LIGHT_ONE_CODE    = 16738455; // Turns on/off light 1.
const int32_t LIGHT_TWO_CODE    = 16750695; // Turns on/off light 2.
const int32_t LIGHT_THREE_CODE  = 16756815; // Turns on/off light 3.
const int32_t CRAZY_LIGHT_CODE  = 16728765; // The lights go crazy.
const int32_t RANDOM_LIGHT_CODE = 16732845; // Truns on/off a random light.
const int32_t CRAZY_CHOICE_CODE = 16730805; // Chooses a light after going crazy.        


// ==================================================== 
//           __   _      __   __    ___  _        
//          / /  (_)__ _/ /  / /_  / _ \(_)__  ___
//         / /__/ / _ `/ _ \/ __/ / ___/ / _ \(_-<
//        /____/_/\_, /_//_/\__/ /_/  /_/_//_/___/
//               /___/                            
// If the pins are already taken on your board that is 
// set below you can change the pins to where you would
// like. this is the pin to the relay control. 
// ==================================================== 

const short LIGHT_ONE_PIN   = 2; // The pin for light 1.
const short LIGHT_TWO_PIN   = 3; // The pin for light 2.
const short LIGHT_THREE_PIN = 4; // The pin for light 3.

// ========================================================
//     __   _      __   __    ____  __     _         __    
//    / /  (_)__ _/ /  / /_  / __ \/ /    (_)__ ____/ /____
//   / /__/ / _ `/ _ \/ __/ / /_/ / _ \  / / -_) __/ __(_-<
//  /____/_/\_, /_//_/\__/  \____/_.__/_/ /\__/\__/\__/___/
//         /___/                     |___/                 
//
// This is where lights can be added or removed depending 
// on the needs of the project. The changes made here will
// be reflected throughout this program.
// ========================================================
Light light1(false,LIGHT_ONE_PIN);   // Creates the 1st light object.
Light light2(false,LIGHT_TWO_PIN);   // Creates the 2nd light object.
Light light3(false,LIGHT_THREE_PIN); // Creates the 3nd light object.

// The number of lights objects.
const int NUM_LIGHTS = 3;

//Array of the three lights pointers.
Light * lights [] = {&light1, &light2, &light3};


// =======================================================
//     _______    _   __              __   ___       
//    /  _/ _ \  | | / /__ ________ _/ /  / (_)__ ___
//   _/ // , _/  | |/ / _ `/ __/ _ `/ _ \/ / / -_|_-<
//  /___/_/|_|   |___/\_,_/_/  \_,_/_.__/_/_/\__/___/
//   
// The pin for the IR receiver sensor can be changed here.                                                
// =======================================================
const short RECV_PIN = 11;  // The pin associated with the IR receiver.
IRrecv irrecv(RECV_PIN);    // Creates The IRrecv object.
decode_results results;     // Stores the results of the IR signal.


// ========================================================
//   ______              __     ____                     
//  /_  __/__  __ ______/ /    / __/__ ___  ___ ___  ____
//   / / / _ \/ // / __/ _ \  _\ \/ -_) _ \(_-</ _ \/ __/
//  /_/  \___/\_,_/\__/_//_/ /___/\__/_//_/___/\___/_/   
//                                                       
// This holds the pin number for the touch pin.l
// ========================================================
const short TOUCH_PIN = 6;

// =============================================================
//     ____    __              ____              __  _         
//    / __/__ / /___ _____    / __/_ _____  ____/ /_(_)__  ___ 
//   _\ \/ -_) __/ // / _ \  / _// // / _ \/ __/ __/ / _ \/ _ \
//  /___/\__/\__/\_,_/ .__/ /_/  \_,_/_//_/\__/\__/_/\___/_//_/
//                  /_/                                        
// =============================================================
void setup(){
  Serial.begin(9600);  // Starts serial communication.
  irrecv.enableIRIn(); // Start the IR receiver
  pinMode(TOUCH_PIN, INPUT);
  for(int i = 0; i < NUM_LIGHTS; i++){
    pinMode(lights[i]->pinNumber, OUTPUT); // Set the pin to output.
  }
  randomSeed(analogRead(0)); // Gets some random "pin static" to seed
  allOff(); // Makes sure the light are off before start up.
}


// ===========================================================
//     __                    ____              __  _         
//    / /  ___  ___  ___    / __/_ _____  ____/ /_(_)__  ___ 
//   / /__/ _ \/ _ \/ _ \  / _// // / _ \/ __/ __/ / _ \/ _ \
//  /____/\___/\___/ .__/ /_/  \_,_/_//_/\__/\__/_/\___/_//_/
//                /_/                                        
//
// This functions main job is read in IR signals and perform 
// the correct function. 
// ===========================================================
void loop() {
  if (irrecv.decode(&results)) {
    IRProcessor(results.value);
    irrecv.resume(); // Receive the next value
  } else if(digitalRead(TOUCH_PIN) == HIGH){
    //Serial.print("TOUCH");
    if(light1.lightStatus || light2.lightStatus|| light3.lightStatus){
      allOff();
      sendStatus();
    } else{
      allOn();
      sendStatus();
    }
    delay(200);
  }
  delay(100);
}


// ==================================================
//     ____        _      __  ____              __    
//    / __/__ ____(_)__ _/ / / __/  _____ ___  / /_   
//   _\ \/ -_) __/ / _ `/ / / _/| |/ / -_) _ \/ __/   
//  /___/\__/_/ /_/\_,_/_/_/___/|___/\__/_//_/\__/    
//    / __/_ _____  ____/ /_(_)__  ___                
//   / _// // / _ \/ __/ __/ / _ \/ _ \               
//  /_/  \_,_/_//_/\__/\__/_/\___/_//_/               
//                                         
//
// This function automatically gets called when a 
// serial signal is sent to the board. If one of the 
// strings below is received the task associated with 
// string will be executed.     
// ==================================================
void serialEvent() {
  proocessSerialData(Serial.read()); // reads in a byte from serial.
}


// ==================================================
//     ___                                      
//    / _ \_______  _______ ___ ___             
//   / ___/ __/ _ \/ __/ -_|_-<(_-<             
//  /_/__/_/  \___/\__/\__/___/___/     __      
//    / __/__ ____(_)__ _/ / / _ \___ _/ /____ _
//   _\ \/ -_) __/ / _ `/ / / // / _ `/ __/ _ `/
//  /___/\__/_/ /_/\_,_/_/_/____/\_,_/\__/\_,_/ 
//    / __/_ _____  ____/ /_(_)__  ___          
//   / _// // / _ \/ __/ __/ / _ \/ _ \         
//  /_/  \_,_/_//_/\__/\__/_/\___/_//_/         
//                                              
// ==================================================                                                                      
void proocessSerialData(byte data){
    switch(data){
    case 'i': // i for info. Send info.
      sendStatus(); break;
    case 'n': // n is for on. turn on all lights.
      IRProcessor(ALL_ON_CODE); break;
    case 'f': // f is for off. turn off all lights.
      IRProcessor(ALL_OFF_CODE); break;
    case 'p': // p is for pick. 
      IRProcessor(CRAZY_CHOICE_CODE); break;  
    case 'c': // c is for crazy lights.
      IRProcessor(CRAZY_LIGHT_CODE); break;
    case '1': // 1 is for light 1. turn light 1 on/off.
      IRProcessor(LIGHT_ONE_CODE); break;
    case '2': // 2 is for light 2. turn light 2 on/off.
      IRProcessor(LIGHT_TWO_CODE); break;
    case '3': // 3 is for light 3. turn light 3 on/off.
      IRProcessor(LIGHT_THREE_CODE); break;
  }
}


// ======================================================
//     _______    ___                                   
//    /  _/ _ \  / _ \_______  _______ ___ ___ ___  ____
//   _/ // , _/ / ___/ __/ _ \/ __/ -_|_-<(_-</ _ \/ __/
//  /___/_/|_| /_/  /_/  \___/\__/\__/___/___/\___/_/   
//    / __/_ _____  ____/ /_(_)__  ___                  
//   / _// // / _ \/ __/ __/ / _ \/ _ \                 
//  /_/  \_,_/_//_/\__/\__/_/\___/_//_/                 
//                                                      
// ======================================================
void IRProcessor(int32_t IRCode){
  
  bool lightsStatus [] =  
      {light1.lightStatus, light2.lightStatus, light3.lightStatus};

  switch(IRCode){
    case ALL_ON_CODE:
      allOn();
      sendStatus(); 
    break;
        
    case ALL_OFF_CODE:
      allOff();
      sendStatus(); 
    break;
        
    case LIGHT_ONE_CODE:
      lightOnOff(light1);
      sendStatus(); 
    break;
        
    case LIGHT_TWO_CODE:
      lightOnOff(light2);
      sendStatus();
    break;
        
    case LIGHT_THREE_CODE:
      lightOnOff(light3);
      sendStatus(); 
    break;
        
    case RANDOM_LIGHT_CODE:
      randomLight();
      sendStatus(); 
    break;

    case CRAZY_CHOICE_CODE:
      for(int i = 0; i < 50; i++){
        randomLight();
        sendStatus();
        delay(100);
      }
      allOff();
      randomLight();
      sendStatus();
    break;
        
    case CRAZY_LIGHT_CODE:
    
      for(int i = 0; i < 100; i++){
        randomLight();
        sendStatus();
        delay(100);
      } 

      for(int i = 0; i < NUM_LIGHTS; i++){
        lights[i]->changeStatus(lightsStatus[i]);
      }
      
      sendStatus(); 
    break;

    case LINE_CODE:
      allOff();
      for(int i = 0; i < 10; i++){
        for(int j = 0; j < 3; j++){
          lightOnOff(*lights[j]);
          sendStatus();
          delay(250);
        }
        delay(100);
        for(int j = 2; j >= 0; j--){
          lightOnOff(*lights[j]);
          sendStatus();
          delay(250);
        }
        delay(100);
        for(int j = 0; j < 3; j++){
          lightOnOff(*lights[j]);
          sendStatus();
          delay(250);
        }
        delay(100);
      }

      for(int i = 0; i < NUM_LIGHTS; i++){
        lights[i]->changeStatus(lightsStatus[i]);
      }
      
      sendStatus();
    break;
  } 
}

// ======================================================
//     __   _      __   __    ____         ____  ______  
//    / /  (_)__ _/ /  / /_  / __ \___    / __ \/ _/ _/  
//   / /__/ / _ `/ _ \/ __/ / /_/ / _ \  / /_/ / _/ _/   
//  /____/_/\_, /_//_/\__/_ \____/_//_/  \____/_//_/     
//    / __//___/__  ____/ /_(_)__  ___                   
//   / _// // / _ \/ __/ __/ / _ \/ _ \                  
//  /_/  \_,_/_//_/\__/\__/_/\___/_//_/                  
//                                               
//
// This function will take in an light object and if it's
// on this fuction will turn it off or vice versa.        
// ======================================================
void lightOnOff(Light& light){
  (light.lightStatus == false) ? light.changeStatus(true): 
  light.changeStatus(false);
}


// =================================================
//     ____            __  ______       __             
//    / __/__ ___  ___/ / / __/ /____ _/ /___ _____    
//   _\ \/ -_) _ \/ _  / _\ \/ __/ _ `/ __/ // (_-<    
//  /___/\__/_//_/\_,_/ /___/\__/\_,_/\__/\_,_/___/    
//    / __/_ _____  ____/ /_(_)__  ___                 
//   / _// // / _ \/ __/ __/ / _ \/ _ \                
//  /_/  \_,_/_//_/\__/\__/_/\___/_//_/                
//                                             
// This function send the current status of the 
// lights through the serial ports.        
// =================================================
void sendStatus(){
    for(int i = 0; i < NUM_LIGHTS; i++){
      Serial.write(lights[i]->lightStatus);
    }
}

// =======================================
//     ___   ____  ____                
//    / _ | / / / / __ \___            
//   / __ |/ / / / /_/ / _ \           
//  /_/_|_/_/_/  \____/_//_/ _         
//    / __/_ _____  ____/ /_(_)__  ___ 
//   / _// // / _ \/ __/ __/ / _ \/ _ \
//  /_/  \_,_/_//_/\__/\__/_/\___/_//_/
//                                     
// This function turns all the lights on 
// and updates the status of the lights.
// =======================================
void allOn(){
  for(int i = 0; i < NUM_LIGHTS; i++){
    lights[i]->changeStatus(true);  
  }
}

// =======================================
//     ___   ____  ____  ______        
//    / _ | / / / / __ \/ _/ _/        
//   / __ |/ / / / /_/ / _/ _/         
//  /_/_|_/_/_/  \____/_//_/ _         
//    / __/_ _____  ____/ /_(_)__  ___ 
//   / _// // / _ \/ __/ __/ / _ \/ _ \
//  /_/  \_,_/_//_/\__/\__/_/\___/_//_/
//                                     
// This function turns all the lights off 
// and updates the status of the lights.
// =======================================
void allOff(){
  for(int i = 0; i < NUM_LIGHTS; i++){
    lights[i]->changeStatus(false);  
  }
}

// =======================================
//     ___                 __               
//    / _ \ ___ _ ___  ___/ /___   __ _     
//   / , _// _ `// _ \/ _  // _ \ /  ' \    
//  /_/__| \___//_//_/__,_/_____//_/_/_/    
//    / /   (_)___ _ / /  / /_              
//   / /__ / // _ `// _ \/ __/              
//  /____//_/ \_, //_//_/\__/               
//           /___/                                                    
//
// This function will trun a random light 
// on or off based on the current light 
// that is selected.
// =======================================            
void randomLight(){
  lightOnOff(*lights[random(NUM_LIGHTS)]);
}
