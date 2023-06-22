using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Net.Sockets;

namespace LaAPI.Models
{
    public class PaymentToken
    {
        public string symbol { get; set; }
        public string address { get; set; }
        public int decimals { get; set; }
    }
    public class PrimaryAssetContract
    {
        public string address { get; set; }
        public string total_supply { get; set; }
        public string image_url { get; set; }
    }
    public class NftsCollectionTrait
    {
        public class mouth
        {
            [BsonElement("m2 bored")]
            public int M2Bored { get; set; }
            [BsonElement("m1 bored")]
            public int M1Bored { get; set; }
            [BsonElement("m1 bored unshaven")]
            public int M1BoredUnShaven { get; set; }
            [BsonElement("m1 dumbfounded")]
            public int M1DumbFounded { get; set; }
            [BsonElement("m1 discomfort")]
            public int M1DisComfort { get; set; }
            [BsonElement("m1 grin")]
            public int M1Grin { get; set; }
            [BsonElement("m2 bored pizza")]
            public int M2BoredPizza { get; set; }
            [BsonElement("m1 bored unshaven cigarette")]
            public int M1BoredUnshavenCigarette { get; set; }
            [BsonElement("m2 bored unshaven cigarette")]
            public int M2BoredUnshavenCigarette { get; set; }
            [BsonElement("m2 bored party horn")]
            public int M2BoredPartyHorn { get; set; }
            [BsonElement("m1 phoneme oh")]
            public int M1PhonemeOh { get; set; }
            [BsonElement("m1 bored unshaven kazoo")]
            public int M1BoredUnshavenKazoo { get; set; }
            [BsonElement("m1 grin gold grill")]
            public int M1GrinGoldGrill { get; set; }
            [BsonElement("m1 bored cigarette")]
            public int M1BoredCigarette { get; set; }
            [BsonElement("m1 tongue out")]
            public int M1TongueOut { get; set; }
            [BsonElement("m2 phoneme wah")]
            public int M2PhonemeWah { get; set; }
            [BsonElement("m1 grin diamond grill")]
            public int M1GrinDiamondGrill { get; set; }
            [BsonElement("m1 phoneme l")]
            public int M1PhonemeL { get; set; }
            [BsonElement("m1 phoneme vuh")]
            public int M1PhonemeVuh { get; set; }
            [BsonElement("m1 phoneme  ooo")]
            public int M1PhonemeOoo { get; set; }
            [BsonElement("m1 bored pipe")]
            public int M1BoredPipe { get; set; }
            [BsonElement("m2 bored unshaven")]
            public int M2BoredUnshaven { get; set; }
            [BsonElement("m1 bored kazoo")]
            public int M1BoredKazoo { get; set; }
            [BsonElement("m1 jovial")]
            public int M1Jovial { get; set; }
            [BsonElement("m1 bored dagger")]
            public int M1BoredDagger { get; set; }
            [BsonElement("m2 rage")]
            public int M2Rage { get; set; }
            [BsonElement("m1 small grin")]
            public int M1SmallGrin { get; set; }
            [BsonElement("m1 rage")]
            public int M1Rage { get; set; }
            [BsonElement("m1 bored unshaven bubblegum")]
            public int M1BoredUnshavenBubblegum { get; set; }
            [BsonElement("m1 phoneme wah")]
            public int M1PhonemeWah { get; set; }
            [BsonElement("m2 phoneme l")]
            public int M2PhonemeL { get; set; }
            [BsonElement("m1 bored cigar")]
            public int M1BoredCigar { get; set; }
            [BsonElement("m1 bored unshaven pipe")]
            public int M1BoredUnshavenPipe { get; set; }
            [BsonElement("m1 bored pizza")]
            public int M1BoredPizza { get; set; }
            [BsonElement("m2 phoneme oh")]
            public int M2PhonemeOh { get; set; }
            [BsonElement("m1 bored unshaven cigar")]
            public int M1BoredUnshavenCigar { get; set; }
            [BsonElement("m2 bored cigarette")]
            public int M2BoredCigarette { get; set; }
            [BsonElement("m2 bored unshaven pipe")]
            public int M2BoredUnshavenPipe { get; set; }
            [BsonElement("m2 bored unshaven bubblegum")]
            public int M2BoredUnshavenBubblegum { get; set; }
            [BsonElement("m2 bored unshaven cigar")]
            public int M2BoredUnshavenCigar { get; set; }
            [BsonElement("m2 discomfort")]
            public int M2Discomfort { get; set; }
            [BsonElement("m2 small grin")]
            public int M2SmallGrin { get; set; }
            [BsonElement("m2 jovial")]
            public int M2Jovial { get; set; }
            [BsonElement("m1 bored unshaven party horn")]
            public int M1BoredUnshavenPartyHorn { get; set; }
            [BsonElement("m2 tongue out")]
            public int M2ToungueOut { get; set; }
            [BsonElement("m1 bored party horn")]
            public int M1BoredPartyHorn { get; set; }
            [BsonElement("m1 grin multicolored")]
            public int M1GrinMulticolored { get; set; }
            [BsonElement("m1 bored bubblegum")]
            public int M1BoredBubblegum { get; set; }
            [BsonElement("m2 bored dagger")]
            public int M2BoredDagger { get; set; }
            [BsonElement("m2 grin")]
            public int M2Grin { get; set; }
            [BsonElement("m2 dumbfounded")]
            public int M2Dumbfounded { get; set; }
            [BsonElement("m2 grin diamond grill")]
            public int M2GrinDiamondGrill { get; set; }
            [BsonElement("m1 bored unshaven pizza")]
            public int M1BoredUnshavenPizza { get; set; }
            [BsonElement("m2 bored kazoo")]
            public int M2BoredKazoo { get; set; }
            [BsonElement("m2 bored unshaven party horn")]
            public int M2BoredUnshavenPartyHorn { get; set; }
            [BsonElement("m2 grin multicolored")]
            public int M2GrinMulticolored { get; set; }
            [BsonElement("m2 bored bubblegum")]
            public int M2BoredBubblegum { get; set; }
            [BsonElement("m2 grin gold grill")]
            public int M2GrinGoldGrill { get; set; }
            [BsonElement("m2 phoneme vuh")]
            public int M2PhonemeVuh { get; set; }
            [BsonElement("m2 phoneme  ooo")]
            public int M2PhonemeOoo { get; set; }
            [BsonElement("m2 bored unshaven kazoo")]
            public int M2BoredUnshavenKazoo { get; set; }
            [BsonElement("m1 bored unshaven dagger")]
            public int M1BoredUnshavenDagger { get; set; }
            [BsonElement("m2 bored pipe")]
            public int M2BoredPipe { get; set; }
            [BsonElement("m2 bored cigar")]
            public int M2BoredCigar { get; set; }
            [BsonElement("m2 bored unshaven dagger")]
            public int M2BoredUnshavenDagger { get; set; }
            [BsonElement("m2 bored unshaven pizza")]
            public int M2BoredUnshavenPizza { get; set; }
        }
        public class hat
        {
            [BsonElement("m2 sushi chef headband")]
            public int M2SushiChefHeadBand { get; set; }
            [BsonElement("m1 beanie")]
            public int M1Beanie { get; set; }
            [BsonElement("m1 horns")]
            public int M1Horns { get; set; }
            [BsonElement("m1 sea captain's hat")]
            public int M1SeaCaptainHat { get; set; }
            [BsonElement("m1 fez")]
            public int M1Fez { get; set; }
            [BsonElement("m1 fisherman's hat")]
            public int M1FishermanHat { get; set; }
            [BsonElement("m1 safari")]
            public int M1Safari { get; set; }
            [BsonElement("m1 girl's hair short")]
            public int M1GirlHairShort { get; set; }
            [BsonElement("m1 s&m hat")]
            public int M1SmHat { get; set; }
            [BsonElement("m2 horns")]
            public int M2Horns { get; set; }
            [BsonElement("m1 bunny ears")]
            public int M1BunnyEars { get; set; }
            [BsonElement("m2 beanie")]
            public int M2Beanie { get; set; }
            [BsonElement("m1 seaman's hat")]
            public int M1SeamanHat { get; set; }
            [BsonElement("m2 halo")]
            public int M1BoredCigarette { get; set; }
            [BsonElement("m1 spinner hat")]
            public int M1SpinnerHat { get; set; }
            [BsonElement("m1 bayc flipped brim")]
            public int M1BaycFlippedBrim { get; set; }
            [BsonElement("m1 bayc hat black")]
            public int M1BaycHatBlack { get; set; }
            [BsonElement("m1 faux hawk")]
            public int M1FauxHawk { get; set; }
            [BsonElement("m2 party hat 1")]
            public int M2PartyHat1 { get; set; }
            [BsonElement("m1 irish boho")]
            public int M1IrishBoho { get; set; }
            [BsonElement("m1 halo")]
            public int M1Halo { get; set; }
            [BsonElement("m2 s&m hat")]
            public int M2SmHat { get; set; }
            [BsonElement("m1 commie hat")]
            public int M1CommieHat { get; set; }
            [BsonElement("m2 sea captain's hat")]
            public int M2SeaCaptainHat { get; set; }
            [BsonElement("m1 short mohawk")]
            public int M1ShortMohawk { get; set; }
            [BsonElement("m2 bowler")]
            public int M2Bowler { get; set; }
            [BsonElement("m2 commie hat")]
            public int M2CommieHat { get; set; }
            [BsonElement("m1 baby's bonnet")]
            public int M1BabyBonnet { get; set; }
            [BsonElement("m1 king's crown")]
            public int M1KingCrown { get; set; }
            [BsonElement("m1 ww2 pilot helm")]
            public int M1Ww2PilotHelm { get; set; }
            [BsonElement("m1 trippy captain's hat")]
            public int M1TrippyCaptainHat { get; set; }
            [BsonElement("m1 bowler")]
            public int M1Bowler { get; set; }
            [BsonElement("m2 cowboy hat")]
            public int M2CowboyHat { get; set; }
            [BsonElement("m1 stuntman helmet")]
            public int M1StuntmanHelmet { get; set; }
            [BsonElement("m1 army hat")]
            public int M1BoredUnshavenCigar { get; set; }
            [BsonElement("m2 girl's hair pink")]
            public int M2GirlHairPink { get; set; }
            [BsonElement("m1 cowboy hat")]
            public int M1CowboyHat { get; set; }
            [BsonElement("m2 short mohawk")]
            public int M2ShortMohawk { get; set; }
            [BsonElement("m1 party hat 1")]
            public int M1PartyHat1 { get; set; }
            [BsonElement("m1 bandana blue")]
            public int M1BandanaBlue { get; set; }
            [BsonElement("m2 bunny ears")]
            public int M2BunnyEars { get; set; }
            [BsonElement("m2 seaman's hat")]
            public int M2SeamanHat { get; set; }
            [BsonElement("m1 sushi chef headband")]
            public int M1SushiChefHeadband { get; set; }
            [BsonElement("m2 stuntman helmet")]
            public int M2StuntmanHelmet { get; set; }
            [BsonElement("m1 girl's hair pink")]
            public int M1GirlHairPink { get; set; }
            [BsonElement("m1 vietnam era helmet")]
            public int M1VietnamEraHelmet { get; set; }
            [BsonElement("m2 fisherman's hat")]
            public int M2FishermanHat { get; set; }
            [BsonElement("m2 police motorcycle helmet")]
            public int M2PoliceMotorcycleHelment { get; set; }
            [BsonElement("m2 fez")]
            public int M2Fez { get; set; }
            [BsonElement("m2 irish boho")]
            public int M2IrishHobo { get; set; }
            [BsonElement("m2 bayc hat black")]
            public int M2BaycHatBlack { get; set; }
            [BsonElement("m1 party hat 2")]
            public int M1PartyHat2 { get; set; }
            [BsonElement("m1 bayc hat red")]
            public int M1BaycHatRed { get; set; }
            [BsonElement("m2 vietnam era helmet")]
            public int M2VietnamEraHelmet { get; set; }
            [BsonElement("m2 party hat 2")]
            public int M2PartyHat2 { get; set; }
            [BsonElement("m2 faux hawk")]
            public int M2FauxHawk { get; set; }
            [BsonElement("m2 bayc flipped brim")]
            public int M2BaycFlippedBrim { get; set; }
            [BsonElement("m2 army hat")]
            public int M2ArmyHat { get; set; }
            [BsonElement("m1 prussian helmet")]
            public int M1PrussianHelmet { get; set; }
            [BsonElement("m2 baby's bonnet")]
            public int M2BabyBonnet { get; set; }
            [BsonElement("m1 police motorcycle helmet")]
            public int M1PoliceMotorcycleHelmet { get; set; }
            [BsonElement("m2 bayc hat red")]
            public int M2BaycHatRed { get; set; }
            [BsonElement("m2 trippy captain's hat")]
            public int M2TrippyCaptainHat { get; set; }
            [BsonElement("m2 ww2 pilot helm")]
            public int M2Ww2PilotHelm { get; set; }
            [BsonElement("m2 king's crown")]
            public int M2KingCrown { get; set; }
            [BsonElement("m2 spinner hat")]
            public int M2SpinnerHat { get; set; }
            [BsonElement("m2 bandana blue")]
            public int M2BandanaBlue { get; set; }
            [BsonElement("m2 prussian helmet")]
            public int M2PrussianHelmet { get; set; }
            [BsonElement("m2 laurel wreath")]
            public int M2LaurelWreath { get; set; }
            [BsonElement("m1 laurel wreath")]
            public int M1LaurelWreath { get; set; }
            [BsonElement("m2 safari")]
            public int M2Safari { get; set; }
            [BsonElement("m2 girl's hair short")]
            public int M2GirlHairShort { get; set; }
        }
        public class eyes
        {
            [BsonElement("m2 bored")] public int M2Bored { get; set; }
            [BsonElement("m1 3d")] public int M13D { get; set; }
            [BsonElement("m1 bloodshot")] public int M1Bloodshot { get; set; }
            [BsonElement("m1 wide eyed")] public int M1WideEyed { get; set; }
            [BsonElement("m1 sleepy")] public int M1Sleppy { get; set; }
            [BsonElement("m1 bored")] public int M1Bored { get; set; }
            [BsonElement("m1 robot")] public int M1Robot { get; set; }
            [BsonElement("m1 crazy")] public int M1Crazy { get; set; }
            [BsonElement("m1 zombie")] public int M1Zombie { get; set; }
            [BsonElement("m1 blue beams")] public int M1BlueBeams { get; set; }
            [BsonElement("m2 angry")] public int M2Angry { get; set; }
            [BsonElement("m2 closed")] public int M2Closed { get; set; }
            [BsonElement("m1 sad")] public int M1Sad { get; set; }
            [BsonElement("m1 closed")] public int M1Closed { get; set; }
            [BsonElement("m1 blindfold")] public int M1BlindFold { get; set; }
            [BsonElement("m2 zombie")] public int M2Zombie { get; set; }
            [BsonElement("m2 3d")] public int M23D { get; set; }
            [BsonElement("m1 sunglasses")] public int M1Sunglasses { get; set; }
            [BsonElement("m2 scumbag")] public int M2ScumBag { get; set; }
            [BsonElement("m2 hypnotized")] public int M2Hypnotized { get; set; }
            [BsonElement("m2 bloodshot")] public int M2BloodShot { get; set; }
            [BsonElement("m1 angry")] public int M1Angry { get; set; }
            [BsonElement("m1 x eyes")] public int M1XEyes { get; set; }
            [BsonElement("m1 eyepatch")] public int M1EyePatch { get; set; }
            [BsonElement("m1 coins")] public int M1Coins { get; set; }
            [BsonElement("m1 hypnotized")] public int M1Hypnotized { get; set; }
            [BsonElement("m1 laser eyes")] public int M1LaserEyes { get; set; }
            [BsonElement("m1 heart")] public int M1Heart { get; set; }
            [BsonElement("m2 sad")] public int M2Sad { get; set; }
            [BsonElement("m2 robot")] public int M2Robot { get; set; }
            [BsonElement("m2 sleepy")] public int M2Sleepy { get; set; }
            [BsonElement("m2 blindfold")] public int M2Blindfold { get; set; }
            [BsonElement("m2 x eyes")] public int M2XEyes { get; set; }
            [BsonElement("m2 crazy")] public int M2Crazy { get; set; }
            [BsonElement("m2 coins")] public int M2Coins { get; set; }
            [BsonElement("m1 holographic")] public int M1Holographic { get; set; }
            [BsonElement("m2 heart")] public int M2Heart { get; set; }
            [BsonElement("m1 scumbag")] public int M1Cumbag { get; set; }
            [BsonElement("m2 sunglasses")] public int M2Sunglasses { get; set; }
            [BsonElement("m2 eyepatch")] public int M2EyePatch { get; set; }
            [BsonElement("m2 wide eyed")] public int M2WideEyed { get; set; }
            [BsonElement("m2 blue beams")] public int M2BlueBeams { get; set; }
            [BsonElement("m1 cyborg")] public int M1Cyborg { get; set; }
            [BsonElement("m2 holographic")] public int M2Holographic { get; set; }
            [BsonElement("m2 laser eyes")] public int M2LaserEyes { get; set; }
            [BsonElement("m2 cyborg")] public int M2Cyborg { get; set; }
        }
        public class clothes 
        {
            [BsonElement("m2 rainbow suspenders")] public int M2RainbowSuspenders { get; set; }
            [BsonElement("m1 leather jacket")] public int M1LeatherJacket { get; set; }
            [BsonElement("m1 puffy vest")] public int M1PuffyVest { get; set; }
            [BsonElement("m1 work vest")] public int M1WorkVest { get; set; }
            [BsonElement("m1 sailor shirt")] public int M1SailorShirt { get; set; }
            [BsonElement("m1 tuxedo tee")] public int M1TuxedoTee { get; set; }
            [BsonElement("m1 lumberjack shirt")] public int M1LumberjackShirt { get; set; }
            [BsonElement("m1 bone tee")] public int M1BoneTee { get; set; }
            [BsonElement("m1 tweed suit")] public int M1TweedSuit { get; set; }
            [BsonElement("m2 guayabera")] public int M2Guayabera { get; set; }
            [BsonElement("m1 stunt jacket")] public int M1StuntJacket { get; set; }
            [BsonElement("m2 black suit")] public int M2BlackSuit { get; set; }
            [BsonElement("m2 navy striped tee")] public int M2NavyStripedTee { get; set; }
            [BsonElement("m1 bayc t red")] public int M1BaycTRed { get; set; }
            [BsonElement("m1 prom dress")] public int M1PromDress { get; set; }
            [BsonElement("m1 hawaiian")] public int M1Hawaiian { get; set; }
            [BsonElement("m1 striped tee")] public int M1StripedTee { get; set; }
            [BsonElement("m1 biker vest")] public int M1BikerVest { get; set; }
            [BsonElement("m1 wool turtleneck")] public int M1WoolTurtleneck { get; set; }
            [BsonElement("m2 tie dye")] public int M2TieDye { get; set; }
            [BsonElement("m1 cowboy shirt")] public int M1CowboyShirt { get; set; }
            [BsonElement("m1 toga")] public int M1Toga { get; set; }
            [BsonElement("m1 caveman pelt")] public int M1CavemanPelt { get; set; }
            [BsonElement("m2 tuxedo tee")] public int M2TuxedoTee { get; set; }
            [BsonElement("m1 vietnam jacket")] public int M1VietnamJacket { get; set; }
            [BsonElement("m1 black holes t")] public int M1BlackHolesT { get; set; }
            [BsonElement("m2 bone tee")] public int M2BoneTee { get; set; }
            [BsonElement("m2 black t")] public int M2BlackT { get; set; }
            [BsonElement("m1 hip hop")] public int M1HipHop { get; set; }
            [BsonElement("m1 guayabera")] public int M1Guayabera { get; set; }
            [BsonElement("m1 smoking jacket")] public int M1SmokingJacket { get; set; }
            [BsonElement("m1 service")] public int M1Service { get; set; }
            [BsonElement("m1 tanktop")] public int M1Tanktop { get; set; }
            [BsonElement("m1 tie dye")] public int M1TieDye { get; set; }
            [BsonElement("m1 black t")] public int M1BlackT { get; set; }
            [BsonElement("m1 bone necklace")] public int M1BoneNecklace { get; set; }
            [BsonElement("m1 sleeveless t")] public int M1SleevelessT { get; set; }
            [BsonElement("m1 rainbow suspenders")] public int M1RainbowSuspenders { get; set; }
            [BsonElement("m2 toga")] public int M2Toga { get; set; }
            [BsonElement("m1 sleeveless logo t")] public int M1SleevelessLogoT { get; set; }
            [BsonElement("m2 work vest")] public int M2WorkVest { get; set; }
            [BsonElement("m2 sleeveless t")] public int M2SleevelessT { get; set; }
            [BsonElement("m1 navy striped tee")] public int M1NavyStripedTee { get; set; }
            [BsonElement("m2 tanktop")] public int M2Tanktop { get; set; }
            [BsonElement("m1 space suit")] public int M1SpaceSuit { get; set; }
            [BsonElement("m2 lumberjack shirt")] public int M2LumberjackShirt { get; set; }
            [BsonElement("m2 vietnam jacket")] public int M2VietnamJacket { get; set; }
            [BsonElement("m2 wool turtleneck")] public int M2WoolTurtleNeck { get; set; }
            [BsonElement("m2 stunt jacket")] public int M2StuntJacket { get; set; }
            [BsonElement("m1 black suit")] public int M1BlackSuit { get; set; }
            [BsonElement("m1 blue dress")] public int M1BlueDress { get; set; }
            [BsonElement("m2 hip hop")] public int M2Hiphop { get; set; }
            [BsonElement("m2 leather punk jacket")] public int M2LeatherPunkJacket { get; set; }
            [BsonElement("m2 smoking jacket")] public int M2SmokingJacket { get; set; }
            [BsonElement("m1 bayc t black")] public int M1BaycTBlack { get; set; }
            [BsonElement("m2 pimp coat")] public int M2PimpCoat { get; set; }
            [BsonElement("m2 striped tee")] public int M2StripedTee { get; set; }
            [BsonElement("m1 bandolier")] public int M1Bandolier { get; set; }
            [BsonElement("m1 leather punk jacket")] public int M1LeatherPunkJacket { get; set; }
            [BsonElement("m2 caveman pelt")] public int M2CavementPelt { get; set; }
            [BsonElement("m2 bone necklace")] public int M2BoneNecklace { get; set; }
            [BsonElement("m2 bayc t red")] public int M2BaycTRed { get; set; }
            [BsonElement("m2 hawaiian")] public int M2Hawaiian { get; set; }
            [BsonElement("m2 cowboy shirt")] public int M2CowboyShirt { get; set; }
            [BsonElement("m1 lab coat")] public int M1LabCoat { get; set; }
            [BsonElement("m2 tweed suit")] public int M2TweedSuit { get; set; }
            [BsonElement("m2 bandolier")] public int M2Bandolier { get; set; }
            [BsonElement("m1 admirals coat")] public int M1AdmiralsCoat { get; set; }
            [BsonElement("m2 service")] public int M2Service { get; set; }
            [BsonElement("m2 biker vest")] public int M2BikerVest { get; set; }
            [BsonElement("m2 leather jacket")] public int M2LeatherJacket { get; set; }
            [BsonElement("m2 sleeveless logo t")] public int M2SleevelessLogoT { get; set; }
            [BsonElement("m2 bayc t black")] public int M2BaycTBlack { get; set; }
            [BsonElement("m2 sailor shirt")] public int M2SailorShirt { get; set; }
            [BsonElement("m2 prison jumpsuit")] public int M2PrisonJumpsuit { get; set; }
            [BsonElement("m2 prom dress")] public int M2PromDress { get; set; }
            [BsonElement("m2 kings robe")] public int M2KingsRobe { get; set; }
            [BsonElement("m1 pimp coat")] public int M1PimpCoat { get; set; }
            [BsonElement("m2 puffy vest")] public int M2PuffyVest { get; set; }
            [BsonElement("m2 lab coat")] public int M2LabCoat { get; set; }
            [BsonElement("m1 prison jumpsuit")] public int M1PrisonJumpsuit { get; set; }
            [BsonElement("m2 blue dress")] public int M2BlueDress { get; set; }
            [BsonElement("m2 space suit")] public int M2SpaceSuit { get; set; }
            [BsonElement("m2 black holes t")] public int M2BlackHolesT { get; set; }
            [BsonElement("m1 kings robe")] public int M1KingsRope { get; set; }
            [BsonElement("m2 admirals coat")] public int M2AdmiralsCoat { get; set; }
        }
        public class background 
        {
            [BsonElement("m2 purple")] public int M2Purple { get; set; }
            [BsonElement("m1 aquamarine")] public int M1Aquamarine { get; set; }
            [BsonElement("m1 orange")] public int M1Orange { get; set; }
            [BsonElement("m1 yellow")] public int M1Yello { get; set; }
            [BsonElement("m1 new punk blue")] public int M1NewPunkBlue { get; set; }
            [BsonElement("m1 blue")] public int M1Blue { get; set; }
            [BsonElement("m1 purple")] public int M1Purple { get; set; }
            [BsonElement("m2 aquamarine")] public int M2Aquamarine { get; set; }
            [BsonElement("m1 gray")] public int M1Gray { get; set; }
            [BsonElement("m2 new punk blue")] public int M2NewPunkBlue { get; set; }
            [BsonElement("m2 gray")] public int M2Gray { get; set; }
            [BsonElement("m2 yellow")] public int M2Yello { get; set; }
            [BsonElement("m2 orange")] public int M2Orange { get; set; }
            [BsonElement("m1 army green")] public int M1ArmyGreen { get; set; }
            [BsonElement("m2 army green")] public int M2ArmyGreen { get; set; }
            [BsonElement("m2 blue")] public int M2Blue { get; set; }
        }
        public class earring 
        {
            [BsonElement("m2 gold stud")] public int M2GoldStud { get; set; }
            [BsonElement("m1 silver hoop")] public int M1SilverHoop { get; set; }
            [BsonElement("m1 silver stud")] public int M1SilverStud { get; set; }
            [BsonElement("m1 diamond stud")] public int M1DiamondStud { get; set; }
            [BsonElement("m1 gold hoop")] public int M1GoldHoop { get; set; }
            [BsonElement("m1 cross")] public int M1Cross { get; set; }
            [BsonElement("m1 gold stud")] public int M1GoldStud { get; set; }
            [BsonElement("m2 cross")] public int M2Cross { get; set; }
            [BsonElement("m2 diamond stud")] public int M2DiamondStud { get; set; }
            [BsonElement("m2 gold hoop")] public int M2GoldHoop { get; set; }
            [BsonElement("m2 silver stud")] public int M2SilverStud { get; set; }
            [BsonElement("m2 silver hoop")] public int M2SilverHoop { get; set; }
        }
        public class name 
        {
            [BsonElement("mega demon")] public int MegaDemon { get; set; }
            [BsonElement("mega swamp")] public int MegaSwamp { get; set; }
            [BsonElement("mega radioactive")] public int MegaRatioactive { get; set; }
            [BsonElement("mega electric")] public int MegaElectric { get; set; }
            [BsonElement("mega jelly")] public int MegaJelly { get; set; }
            [BsonElement("mega robot")] public int MegaRobot { get; set; }
            [BsonElement("mega death bot")] public int MegaDeathBot { get; set; }
            [BsonElement("mega zombie")] public int MegaZombie { get; set; }
            [BsonElement("mega noise")] public int MegaNoise { get; set; }
            [BsonElement("mega dmt")] public int MegaDmt { get; set; }
            [BsonElement("mega trippy")] public int MegaTrippy { get; set; }
            [BsonElement("mega gold")] public int MegaGold { get; set; }
        }
        public class fur 
        {
            [BsonElement("m2 gray")] public int M2Gray { get; set; }
            [BsonElement("m1 pink")] public int M1Pink { get; set; }
            [BsonElement("m1 black")] public int M1Black { get; set; }
            [BsonElement("m1 dark brown")] public int M1DarkBrown { get; set; }
            [BsonElement("m1 tan")] public int M1Tan { get; set; }
            [BsonElement("m1 gray")] public int M1Gray { get; set; }
            [BsonElement("m1 dmt")] public int M1Dmt { get; set; }
            [BsonElement("m1 blue")] public int M1Blue { get; set; }
            [BsonElement("m1 brown")] public int M1Brown { get; set; }
            [BsonElement("m1 golden brown")] public int M1GoldenBrown { get; set; }
            [BsonElement("m2 brown")] public int M2Brown { get; set; }
            [BsonElement("m1 red")] public int M1Red { get; set; }
            [BsonElement("m2 black")] public int M2Black { get; set; }
            [BsonElement("m1 trippy")] public int M1Trippy { get; set; }
            [BsonElement("m1 cream")] public int M1Cream { get; set; }
            [BsonElement("m2 blue")] public int M2Blue { get; set; }
            [BsonElement("m1 zombie")] public int M1Zombie { get; set; }
            [BsonElement("m1 cheetah")] public int M1Cheetah { get; set; }
            [BsonElement("m1 robot")] public int M1Robot { get; set; }
            [BsonElement("m1 death bot")] public int M1DeathBot { get; set; }
            [BsonElement("m2 dark brown")] public int M2DarkBrown { get; set; }
            [BsonElement("m2 golden brown")] public int M2GoldenGrown { get; set; }
            [BsonElement("m1 white")] public int M1White { get; set; }
            [BsonElement("m2 pink")] public int M2Pink { get; set; }
            [BsonElement("m2 cream")] public int M2Cream { get; set; }
            [BsonElement("m2 noise")] public int M2Noise { get; set; }
            [BsonElement("m2 robot")] public int M2Robot { get; set; }
            [BsonElement("m2 white")] public int M2White { get; set; }
            [BsonElement("m2 cheetah")] public int M2Cheetah { get; set; }
            [BsonElement("m2 tan")] public int M2Tan { get; set; }
            [BsonElement("m1 solid gold")] public int M1SolidGold { get; set; }
            [BsonElement("m2 zombie")] public int M2Zombie { get; set; }
            [BsonElement("m1 noise")] public int M1Noise { get; set; }
            [BsonElement("m2 red")] public int M2Red { get; set; }
            [BsonElement("m2 trippy")] public int M2Trippy { get; set; }
            [BsonElement("m2 solid gold")] public int M2SolidGold { get; set; }
            [BsonElement("m2 death bot")] public int M2DeathBot { get; set; }
            [BsonElement("m2 dmt")] public int M2Dmt { get; set; }
        }
        public mouth Mouth { get; set; }
        public hat Hat { get; set; }
        public eyes Eyes { get; set; }
        public clothes Clothes { get; set; }
        public fur Fur { get; set; }
        public background Background { get; set; }
        public earring Earring { get; set; }
        public name Name { get; set; }
    }
    public class NftCollectionStats
    {
         public double one_minute_volume { get; set; }
         public double one_minute_change { get; set; }
         public double one_minute_sales { get; set; }
         public double one_minute_sales_change { get; set; }
         public double one_minute_average_price { get; set; }
         public double one_minute_difference { get; set; }
         public double five_minute_volume { get; set; }
         public double five_minute_change { get; set; }
         public double five_minute_sales { get; set; }
         public double five_minute_sales_change { get; set; }
         public double five_minute_average_price { get; set; }
         public double five_minute_difference { get; set; }
         public double fifteen_minute_volume { get; set; }
         public double fifteen_minute_change { get; set; }
         public double fifteen_minute_sales { get; set; }
         public double fifteen_minute_sales_change { get; set; }
         public double fifteen_minute_average_price { get; set; }
         public double fifteen_minute_difference { get; set; }
         public double thirty_minute_volume { get; set; }
         public double thirty_minute_change { get; set; }
         public double thirty_minute_sales { get; set; }
         public double thirty_minute_sales_change { get; set; }
         public double thirty_minute_average_price { get; set; }
         public double thirty_minute_difference { get; set; }
         public double one_hour_volume { get; set; }
         public double one_hour_change { get; set; }
         public double one_hour_sales { get; set; }
         public double one_hour_sales_change { get; set; }
         public double one_hour_average_price { get; set; }
         public double one_hour_difference { get; set; }
         public double six_hour_volume { get; set; }
         public double six_hour_change { get; set; }
         public double six_hour_sales { get; set; }
         public double six_hour_sales_change { get; set; }
         public double six_hour_average_price { get; set; }
         public double six_hour_difference { get; set; }
         public double one_day_volume { get; set; }
         public double one_day_change { get; set; }
         public double one_day_sales { get; set; }
         public double one_day_sales_change { get; set; }
         public double one_day_average_price { get; set; }
         public double one_day_difference { get; set; }
         public double seven_day_volume { get; set; }
         public double seven_day_change { get; set; }
         public double seven_day_sales { get; set; }
         public double seven_day_average_price { get; set; }
         public double seven_day_difference { get; set; }
         public double thirty_day_volume { get; set; }
         public double thirty_day_change { get; set; }
         public double thirty_day_sales { get; set; }
         public double thirty_day_average_price { get; set; }
         public double thirty_day_difference { get; set; }
         public double total_volume { get; set; }
         public double total_sales { get; set; }
         public double total_supply { get; set; }
         public double count { get; set; }
         public double num_owners { get; set; }
         public double average_price { get; set; }
         public double num_reports { get; set; }
         public double market_cap { get; set; }
         public double floor_price { get; set; }
    }
    public class TraitRarity
    {
        
    }

    // Main
    public class NftsCollection
    {
        [BsonId]
        public string Id { get; set; }
        public List<PaymentToken> payment_tokens { get; set; }
        public PrimaryAssetContract primary_asset_contracts { get; set; }
        public NftsCollectionTrait traits { get; set; }
        public NftCollectionStats stats { get; set; }
        public DateTime created_date { get; set; }
        public string name { get; set; }
        public string discord_url { get; set; }
        public string telegram_url { get; set; }
        public string twitter_username { get; set; }
        public string instagram_username { get; set; }
        public string wiki_url { get; set; }
        public TraitRarity traits_rarity { get; set; }
    }
}
