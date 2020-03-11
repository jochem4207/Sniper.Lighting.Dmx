# My purpose for this repo 
Creating a better audio-to-dmx software
To 
- Create lightshow on music
- A better sound to dmx for my home setup

Using
- hardware: Enttec dmx pro interface (MK1) 
- software: QLC+ webapi (suggestion of the facebook group: https://www.facebook.com/groups/lightingtrainer/?fref=nf)

End goals
- Traktor pro 3 to <my open custom software> to dmx 
- Document most steps so it can help people in the future
- Make a video how to use
  
# Steps to go

## New plan 
- [ ] Get more knowledge about everything
- [ ] Create a custom made show in QLC+
- [ ] Learn how to mix a song in Traktor DJ


Below is on hold.

## For the basic lightning
- [ ] Make a plan
- [ ] Create a C# App (api, tbd) that can talk with QLC+
- [ ] Create sequences in QLC+ to be called from the web api
- [ ] Call and make basic show 

## For the sound part
- [ ] Test the sound functions of QLC+
- [ ] If needed develop something as input for the C# App based on sound input 


# Sources used
- [ ] https://www.qlcplus.org/tutorials.html to get a basic understanding of qlc+ 

# Optional 
- [ ] Create a plugin like this one for Traktor Pro 3 (https://github.com/VDJartnet/VDJartnet) idea came from (https://www.qlcplus.org/forum/viewtopic.php?f=30&t=12303)

# History
- Tried this repo, didn't work, no signals were actually send (see https://github.com/agrath/Sniper.Lighting.Dmx/issues/4)
- Tried QuickQ, MagicQ, seem far to complex
- Tried SoundSwitch, has no sound 2 dmx (lovely software tho)
- Tried FreeStyler with Sound 2 dmx, is only sending random dmx signals, i need more control. Good stuff if you want random dmx.
- Tried OLA (but hell, that stuff is old and hard to install on a ubuntu vm)
- Tried a fork of this repo (https://github.com/neoxai/Sniper.Lighting.Dmx) couldn't get the example to work yet, didn't invest much time. I changed my mind to start working on the QLC+ example. Due this software is currently being maintained.

# Stuff to look into 
- OS2L 
- Timecode 
