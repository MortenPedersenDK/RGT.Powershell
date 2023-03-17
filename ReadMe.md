# Wahoo RGT Powershell event organizer tools

This project is aiming at helping event organizers on the [Wahoo RGT](https://rgtcycling.com) Esports Cycling platform with a set of Powershell Cmdlets(Commandlets) to create events and pull results.

## Contents

- Installation
- Connecting to RGT API
- Roads
- Events
- Results
- Race Radio


# Installation

(Need something here about downloading at setting it up on users PC)

Easiest way to use the tools is by adding the following line of code to your Powershell file:

```
Import-Module C:\temp\Powershell\RGT.Powershell\RGT.Powershell.dll
```

In the case above the RGT.Powershell tools has been copied to `c:\temp\Powershell` folder. Please adjust to where you have placed your copy.
 
# Connecting to RGT API

The RGT API is not publicly available. In order to access them, you need a RGT login, and to use branding features you need to have Wahoo RGT to enable that on your login.

## Connect-RGTService

This command establishes a connection to RGT API. The connection is kept as long as the Powershell window is open. There is no need to close the connection when done. Calling `Connect-RGTService` again will override the previous connection.

```
Connect-RGTService -Login "name@domain.com" -Password "abcdefgh"
```

Parameters:
- Login: Your RGT username
- Password: Your RGT password

# Roads
The following commands perform operations on roads

## Get-RGTRealRoads
### Description
Get a list of real roads.
### Syntax
```
Get-RGTRealRoads
```
### Parameters
None

### Returns
A List object containing all real roads.

### Example
```
PS C:\Users\Morten> Get-RGTRealRoads | FT Id, Length, Elevation, Label

    Id Length Elevation Label                             
    -- ------ --------- -----                             
    94   7700        19 Borrego                           
    70   1035         5 Canary Wharf                      
   109  22431       515 Cap Formentor                     
166473   8881       168 De Ronde                          
 80192  17657       225 Dirty Reiver                      
391341  14298       307 The Dunoon Crossover              
204780  27767       319 Iron Horse Bicycle Classic Durango
203996  15355       136 Leuven City, Flanders             
    54  25521      1596 Mont Ventoux                      
    47  14083      1114 Passo dello Stelvio               
    86   4183       102 Paterberg                         
    62   8202       235 Pienza                            
   102    969         0 Tempelhof Airport      
```


## Get-RGTMagicRoads
### Description
Get a list of magic roads.
### Syntax
```
Get-RGTMagicRoads
```
### Parameters
None

### Returns
A List object containing all real roads in users inventory.

### Example
```
PS C:\Users\Morten> Get-RGTMagicRoads | FT Name, Label, Length, Elevation

Name         Label                                              Length Elevation
----         -----                                              ------ ---------
ZGhY4GzxaOQa Aakirkeby, Bornholm, Denmark                         7953        48
PuKnpLeXhzZz Agerskov Street Race, Denmark                        1995        16
eoXTIgWbaDS7 Alpe D'Huez Climb                                   19064      1127
Zk3oxp0BH1Y5 Amstel Gold Loop                                    15482       171
CdJZ6XWaXfPO Around Nakskov, Lolland, Denmark                    20665        59
5OMLEs1P4Jx3 Around Reykjavik, Fossvogsbakkar, Iceland           25758       114
yvyJb681qCEA Birket, Glentehøj, Lolland, Denmark                 10126        47
mumBzQygFBi2 BlueHors-Tørskind-Egtved-Loop, Denmark              18324       300
TSIUncGT2xny Bording Loop, Ikast, Denmark                         7228        37
```

## Import-MagicRoad
### Description
Import someone elses magic road to your inventory in order to create an event using that road.

### Syntax
```
Import-RGTMagicRoad -Identity "<road id>"
```

### Parameters
- Identity: The ID of the road to import.

### Returns
If successful the ID of the imported road is returned

### Example
```
PS C:\Users\Morten> Import-RGTMagicRoad -Identity "8giWXwqeL9Gt" 
TEESMR25Pd1b
```
This example imports the Mortirolo magic road and returns the ID in this users Magic Roads inventory.

# Events

## New-RGTBrandingContainer
### Description
Creates a new container for branding files.
### Syntax
```
New-RGTBrandingContainer [-Brandingfolder]
```

### Parameters
- Brandingfolder: An optional parameter. If it is specified the command looks for branding files following a naming convention in the provided folder. For more information see Branding file naming convention below.

### Returns
A Branding object where paths to individual branding files can be set.

### Example 1
```
$branding = New-RGTBrandingContainer
$branding.EventThumbnail = "C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\EventThumbnail.png"
```

Creates an empty branding container and specifies location of event thumbnail image. 

*Note:* Command does not verify if file exists.

### Example 2
```
$branding = New-RGTBrandingContainer -BrandingFolder C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2
```
A new $branding variable is created and the specified folder is scanned for brandingfiles and added to the container. If we type `$branding`and hit enter we will see the contents of the container:
```
PS C:\Users\Morten> $branding


EventThumbnail  : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\EventThumbnail.png
Billboard01     : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\Billboard01.png
Billboard02     : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\Billboard02.png
Billboard03     : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\Billboard03.png
Fence01         : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\Fence01.png
Fence02         : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\Fence02.png
Fence03         : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\Fence03.png
Fence04         : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\Fence04.png
Fence05         : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\Fence05.png
Fence06         : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\Fence06.png
Flag01          : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\Flag01.png
Flag02          : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\Flag02.png
Flag03          : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\Flag03.png
GateMainTop     : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\GateMainTop.png
GateMainSide    : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\GateMainSide.png
Decal01         : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\Decal01.png
Decal02         : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\Decal02.png
SignDistance    : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\SignDistance.png
TentBasicTop    : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\TentBasicTop.png
TentBasicWall   : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\TentBasicWall.png
TentTechTop     : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\TentTechTop.png
TentTechWall    : C:\users\Morten\Pictures\RGTAssets\RGTLigaBrandingV2\TentTechWall.png
GateSegmentTop  : 
GateSegmentSide : 
```

### Branding file naming convention
In order for this command to discover the branding files, they must be named after which branding asset it is. The convention is \<assetname\>.png:

- EventThumbnail.png
- Billboard01.png
- Billboard02.png
- Billboard03.png
- Fence01.png
- Fence02.png
- Fence03.png
- Fence04.png
- Fence05.png
- Fence06.png
- Flag01.png
- Flag02.png
- Flag03.png
- GateMainTop.png
- GateMainSide.png
- Decal01.png
- Decal02.png
- SignDistance.png
- TentBasicTop.png
- TentBasicWall.png
- TentTechTop.png
- GateSegmentTop.png
- GateSegmentSide.png

## New-RGTEvent
### Description
Creates a new event

### Syntax
```
New-RGTEvent 
  -Start <string> 
  -EventName <string> 
  -EventDescription <string> 
  -RoadUID <string> 
  [-Laps <int> ]
  [-Scene (Classic | Spring_in_Europe) ]
  [-Public]
  [-Branding <Branding>]
  [-Bots <int>]
  [-BotsMinPwr <int>]
  [-BotsType (Pacing | Real)]
  [-BotsMode (Beginner | Custom | Distributed | Expert | Intermediate)]
  [-BotsMaxPwr <int>]
  [-RaceType (Race | Group)]
  [-ReleaseGap]
  [-RidersPerRelease]
  [-Rubberband]
  [-NoDrafting]
  [-NoMassStart]

```

### Parameters
- Start: (Mandatory) A string representing the start of the event in local time in the following format: dd-mm-yyyy HH:MM
- EventName: (Mandatory) The name of the event as shown in RGT
- EventDescription: (Mandatory) The descriptive text displayed under the event
- RoadUID: (Mandatory) The ID of the real road or magic road. If RoadUID is numeric, it is considered a real road. If the RoadUID is alfanumeric it is considered a magic road. In this case the connected users inventory is checked for such a road and if not found the command tries to import that magic road to users repository.
- Laps: The number of laps to do on route. Default value is 1.
- Scene: Which scene to use for graphics. Default is Classic.
- Public: Switchparameter. Makes event searchable in RGT Web.
- Bots: The number of bots to have in the event. Default is 0.
- BotsMinPwr: Minimum power for bots. Default is 70.
- BotsType: Default is Real
- BotsMode: Behavior of the bots. Default is Beginner.
- BotsMaxPwr: Maximum power of bots. Default is 310.
- RaceType: Whether this is a race or a group ride. Default is Race.
- ReleaseGap: Used for timetrials. The time(seconds) between a group of riders are started. Default 15.
- RidersPerRelease: How many riders are started in each slot. Default is 1.
- Rubberband: Switchparameter. Enables rubberband effect in group rides.
- NoDrafting: Switchparameter. Disables drafting
- NoMassstart: Switchparameter. Disables massstart thus enabling riders to be released according to the ReleaseGap and RidersPerRelease parameters.

### Returns
An Event object containing event information such as:
- Event id
- Signup URL
- Total distance
- Total elevation.

### Example: Creating basic race
```
PS C:\Users\Morten> $myevent = New-RGTEvent -Start "15-03-2023 22:00" -EventName "Test event" -EventDescription "This is a test" -RoadUID 94 -Laps 4 -Public

PS C:\Users\Morten> $myevent


EventId        : NU28TG
SignupLink     : https://user.rgtcycling.com/event?code=NU28TG
TotalDistance  : 30800
TotalElevation : 76
Title          : Test event
Laps           : 4
```
This example creates a 4 lap race on Borrego Springs starting at 22:00 on March 15th. 2023 local time.

### Example: Creating multiple events from a .CSV file exported from a spreadsheet
```
$branding = New-RGTBrandingContainer -BrandingFolder C:\users\Morten\Pictures\RGTAssets\DM2023BrandingV1
$disclaimer = Get-Content 'C:\Users\Morten\Documents\Disclaimer_DMOpen.txt' -Raw -Encoding UTF8
$races = Import-Csv -LiteralPath 'C:\users\Morten\Downloads\DM Open 2023 - Sheet1.csv' -Delimiter "," -Header Start, Title, Road, Laps
$races | ForEach-Object {
    $event = New-RGTEvent -Start $_.Start -EventName $_.Title -EventDescription $disclaimer -RoadUID $_.Road -Laps $_.Laps -Scene Classic -Branding $branding
    if($event -ne $null) {
        $event.EventId
        $event.SignupLink
    }
}
```
What it does:

First a branding container for all events is created with assets from DM2023BrandingV1 folder:
```
$branding = New-RGTBrandingContainer -BrandingFolder C:\users\Morten\Pictures\RGTAssets\DM2023BrandingV1
```
Then a descriptive text(in this case a disclaimer) for all events are loaded:

```
$disclaimer = Get-Content 'C:\Users\Morten\Documents\Disclaimer_DMOpen.txt' -Raw -Encoding UTF8
```
Events are created in an spreadsheet and exported as CSV with a comma seperating values. This is the contents of that file:
```
11-03-2023 11:00,Open 1: Borrego TT,94,2
11-03-2023 12:30,Open 2: Canary Wharf,70,10
11-03-2023 14:15,Open 3: Paterberg,86,3
11-03-2023 16:00,Open Finale: Gunnars Dødsrute,mumBzQygFBi2,1
```
In this case the format is as follows:

Start,Title,RoadUID,Laps

This is loaded in to Powershell using the standard Powershell command `Import-CSV`. We tell this command to name first column 'Start', then 'Title', 'Road' and 'Laps'. This is important when we later want to reference those values.

```
$races = Import-Csv -LiteralPath 'C:\users\Morten\Downloads\DM Open 2023 - Sheet1.csv' -Delimiter "," -Header Start, Title, Road, Laps
```
Please note that you can easily change the format of the CSV file and include more options if necessary.

With the branding, descriptive text and race information loaded, we are ready to loop over the rows from the CSV file and mass create events. The following will process each line in the CSV one at a time:

```
$races | ForEach-Object {
}
```

Now we come to the exiting part where we create the actual event. Inside our `ForEach-Object` loop we access the current element(line) by typing `$_`and then the column name as we specified in the `Import-Csv` command above.

```
    $event = New-RGTEvent -Start $_.Start -EventName $_.Title -EventDescription $disclaimer -RoadUID $_.Road -Laps $_.Laps -Scene Classic -Branding $branding
```

If creation is successful, an Event object is returned with EventId and SignupLink:
```
    if($event -ne $null) {
        $event.EventId
        $event.SignupLink
    }
```

# Results

## Get-RGTRaceResult

### Description
Gets a result from an event including signed up riders, segment results and the race result in itself.

### Syntax
Get-RGTResult -EventId \<eventid\>

### Parameters
- EventId: The id of the event, for example EVY23E

### Returns
If successful an EventResult object containing the following properties:
- Name \<string\>
- Result \<list\>
- Segments \<list\>
- Signups \<list\>

**Result:**

A list of Rider objects containing riders name and details like weight, height, country etc.

**Segments**

A list of segments if route contains any. Each Segment element contains a list of Result objects with time and rider for each passage of the segment.

Each Segment object also contains a `GetRidersBest()` method that returns a list with each riders best segment result for that segment in that race.


### Example 1
```
$result = Get-RGTResult -EventId "EVY23E"

$result.Result | FT Rank, Rider, Time, Distance, Kmh, AvgPwr, Best20MinPwr, AvgHr
```
Retrieves the result and prints a result list to the console.

### Example 2
```
$result = Get-RGTResult -EventId "EVY23E"

$result.Signups | Sort-Object -Property Name | Format-Table Name, CountryName, Age, Weight, Height, Gender
```
Prints a list of all signed up riders ordered by their name.

### Example 3

```
$result = Get-RGTResult -EventId "EVY23E"

$result.Segments[0].GetRidersBest()
```
Prints the classification for the first segment.


# Race Radio
## Add-RGTRaceRadioUser
### Description
Add a user to be able to talk in the race radio.

### Syntax
Add-RGTRaceRadioUser -EventId \<string\> -UserEmail \<string\>

### Parameters
- EventId: The id of the event, for example EVY23E
- UserEmail: The email address/login of the user to add

### Returns
`$true` if successful

### Example
```
Add-RGTRaceRadioUser -EventId "EVY23E" -UserEmail "john.doe@domain.com"
```

## Get-RaceRadioUsers
### Description
### Syntax
### Parameters
### Returns
### Example
## Remove-RaceRadioUser
### Description
### Syntax
### Parameters
### Returns
### Example







