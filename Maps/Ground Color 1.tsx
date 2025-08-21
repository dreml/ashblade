<?xml version="1.0" encoding="UTF-8"?>
<tileset version="1.10" tiledversion="1.11.2" name="Ground Color 1" tilewidth="64" tileheight="64" tilecount="160" columns="20">
 <image source="D:/GameDev/Art/Tiny Swords/Terrain/Tilemap_color1.png" width="1280" height="512"/>
 <tile id="36">
  <objectgroup draworder="index" id="2">
   <object id="2" x="32" y="64">
    <polygon points="0,0 32,-32 32,0"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="38">
  <objectgroup draworder="index" id="2">
   <object id="1" x="32" y="64">
    <polygon points="0,0 -32,-32 -32,0"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="56">
  <objectgroup draworder="index" id="2">
   <object id="2" x="0" y="32">
    <polygon points="0,0 32,-32 64,-32 64,32 0,32"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="58">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="0">
    <polygon points="0,0 32,0 64,32 64,64 0,64"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="101">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="32">
    <polygon points="0,0 64,0 64,32 0,32"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="102">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="32">
    <polygon points="0,0 64,0 64,32 0,32"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="103">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="32">
    <polygon points="0,0 64,0 64,32 0,32"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="111">
  <objectgroup draworder="index" id="2">
   <object id="1" x="0" y="32">
    <polygon points="0,0 64,0 64,32 0,32"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="112">
  <objectgroup draworder="index" id="5">
   <object id="10" x="0" y="32" width="64" height="32"/>
  </objectgroup>
 </tile>
 <tile id="113">
  <objectgroup draworder="index" id="2">
   <object id="2" x="0" y="32">
    <polygon points="0,0 64,0 64,32 0,32"/>
   </object>
  </objectgroup>
 </tile>
 <wangsets>
  <wangset name="Ground" type="edge" tile="-1">
   <wangcolor name="Grass" color="#ff0000" tile="-1" probability="1"/>
   <wangtile tileid="101" wangid="0,0,1,0,0,0,0,0"/>
   <wangtile tileid="102" wangid="0,0,1,0,0,0,1,0"/>
   <wangtile tileid="103" wangid="0,0,0,0,0,0,1,0"/>
  </wangset>
 </wangsets>
</tileset>
