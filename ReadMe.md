# Intellinet 163682 smart PDU API Wrapper
## A C# API wrapper for Intellinet 163682 smart PDU

This project was inspired by the following projects:

* [Intellinet IP smart PDU API 163682](https://github.com/01programs/Intellinet_163682_IP_smart_PDU_API) (Python)
* [node-intellinet-pdu](https://github.com/bitcraftlab/node-intellinet-pdu) (Node.js)

However, since I needed to control the unit from a .net application, I wrote this little wrapper.
Also included is a little command line tool to read the sensors and outlet states and switch outlets on or off.

The wrapper has no error handling of any kind, so if you feed it with wrong parameters, it'll just crash :smile:
Since configuration normally doesn't need to be scripted or automated, there is no configuration of the PDU implemented.