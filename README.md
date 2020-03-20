# My purpose for this repo 
Creating a better audio-to-dmx software
To 
- Create lightshow on music
- A better sound to dmx for my home setup

Using
- hardware: Enttec dmx pro interface (MK1) 
- software: QLC+ / TouchDesigner

End goals
- Traktor pro 3 to Any (free) software to dmx to create an awesome show
- Document most steps so it can help people in the future
- Make a video how to use
 
# Thanks to
QLC+ (For the whole app ofc)    
The Artnetominator (Debugging)    
R3Crowderz (#music#)   
TouchDesigner (An very open, creative program to create everything you can imagine)    
The LD group on fb https://www.facebook.com/groups/lightingtrainer/?fref=nf    

# Setup
QLC+ for fixture control    
Touchdesigner for analyzing music     
Touchdesigner -> QLC (via DMX out, artnet, out of the box by these two programs)    
 
# Steps to go
- [ ] Audio processing on TouchDesigner 
- [ ] Configuring scenes, chases in QLC+ for to be triggered on certain sound 
- [ ] Get more knowledge about everything (in progress)
- [ ] Create a custom made show in QLC+ (in progress)
- [ ] Learn how to mix a song in Traktor DJ (in progress)

## For the sound part
- [X] Test the sound functions of QLC+ -> not working properly (sound analyze is minimal, QLC+ is for lightning, not music)

# Sources used
- [X] https://www.qlcplus.org/tutorials.html to get a basic understanding of qlc+ 
- [X] Everything in History

# Optional 
- [ ] Create a plugin like this one for Traktor Pro 3 (https://github.com/VDJartnet/VDJartnet) idea came from (https://www.qlcplus.org/forum/viewtopic.php?f=30&t=12303)
- [ ] Make a tutorial video once i've found my perfect setup

# History
- Tried this repo, didn't work, no signals were actually send (see https://github.com/agrath/Sniper.Lighting.Dmx/issues/4)
- Tried QuickQ, MagicQ, seem far to complex
- Tried SoundSwitch, has no sound 2 dmx (lovely software tho)
- Tried FreeStyler with Sound 2 dmx, is only sending random dmx signals, i need more control. Good stuff if you want random dmx.
- Tried OLA (but hell, that stuff is old and hard to install on a ubuntu vm)
- Tried a fork of this repo (https://github.com/neoxai/Sniper.Lighting.Dmx) couldn't get the example to work yet, didn't invest much time. I changed my mind to start working on the QLC+ example. Due this software is currently being maintained.
- Tried Lightjams (didnt do much with it, touchdesigner is my goal now)

# Stuff to look into 
- OS2L (done, not promising for my purpose at this moment)
- Timecode (done, maybe for someday)
