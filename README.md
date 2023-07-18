# DeskLights

This project is to turn off and on the 3 lights above my desk.

# Interface

[x] A GUI application for Windows based computers.

[x] A touch sensor.

[x] Infrared controller.

The hardware side of the project uses mains power to power the lights using relays. So, I'm NOT going to show the mains power side of the project for safety reasons.

The project uses a: 

+ [Relay Shield Module](https://www.amazon.com/SunFounder-Channel-Shield-Arduino-Raspberry/dp/B00E0NSORY/ref=sxin_16_pa_sp_search_thematic_sspa?content-id=amzn1.sym.1c86ab1a-a73c-4131-85f1-15bd92ae152d%3Aamzn1.sym.1c86ab1a-a73c-4131-85f1-15bd92ae152d&cv_ct_cx=arduino+power+relay&hvadid=233519703749&hvdev=c&hvlocphy=9030790&hvnetw=g&hvqmt=e&hvrand=8838576990085156139&hvtargid=kwd-93155230140&hydadcr=18889_10145740&keywords=arduino+power+relay&pd_rd_i=B00E0NSORY&pd_rd_r=8ddb2110-0099-49a3-87a6-d6a299d938af&pd_rd_w=jQWlx&pd_rd_wg=EORwD&pf_rd_p=1c86ab1a-a73c-4131-85f1-15bd92ae152d&pf_rd_r=5EBHXSS007SVZBQDN2YR&qid=1689701842&sbo=RZvfv%2F%2FHxDF%2BO5021pAnSA%3D%3D&sr=1-1-364cf978-ce2a-480a-9bb0-bdb96faa0f61-spons&sp_csd=d2lkZ2V0TmFtZT1zcF9zZWFyY2hfdGhlbWF0aWM&psc=1): This allows for the UNO R3 Board to control what lights get power.

+ [UNO R3 Board ATmega328P](https://www.amazon.com/UNO-Board-ATmega328P-Cable-Arduino/dp/B09NQQS777/ref=sr_1_17_sspa?crid=2KR9LPD8G1YUA&keywords=arduino+uno&qid=1689702445&s=industrial&sprefix=arduino+uno%2Cindustrial%2C189&sr=1-17-spons&sp_csd=d2lkZ2V0TmFtZT1zcF9tdGY&psc=1): controls the hardware based on a sginal from a IR conetaoler, GUI app, or touch seonsor. 

+ [Amazon Basics USB-A to USB-B 2.0 Cable](https://www.amazon.com/Amazon-Basics-External-Gold-Plated-Connectors/dp/B00NH13DV2/ref=sr_1_3?crid=194MGGUTQYRUD&keywords=amazon%2Bbasics%2Busb%2Bb%2Bto%2Ba&qid=1689702610&s=industrial&sprefix=amazon%2Bbasics%2Busb%2Bbb%2Bto%2B%2Cindustrial%2C121&sr=1-3&th=1): The GUI application works off of a serial connection to send and receive data to the UNO R3 Board. This cable gives a good length to send that signal. 

+ [Infrared Wireless Remote Control IFR Sensor Module](https://www.amazon.com/HiLetgo-HX1838-Infrared-Wireless-Control/dp/B01HTC5JX4/ref=sr_1_11?crid=29K5KIW8476WK&keywords=arduino+ir+remote+and+receiver&qid=1689702874&s=industrial&sprefix=arduino+IR+%2Cindustrial%2C123&sr=1-11): Sends a signal that the UNO R3 Board can take in and cause an action like turning off and on a light. 

+ [Digital Capacitive Touch Sensor](https://www.amazon.com/WWZMDiB-TTP223B-Digital-Capacitive-Raspberry/dp/B0BG2694RX/ref=sr_1_3?crid=1IWS0ZFKV1WDS&keywords=arduino+touch&qid=1689702988&s=industrial&sprefix=arduino+touch%2Cindustrial%2C124&sr=1-3): A touch sensor to turn off and on all the lights depending on the current state of the lights.

This README mainly focused on the GUI to Lights interaction, but you can find the code for the touch sensor and IR control in the crazy light folder. The microcontroller controls all physical interaction

<img src="/gifs/video.gif?raw=true" width="" alt= 'Video Walkthrough'>
