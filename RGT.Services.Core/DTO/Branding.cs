using System.IO;

namespace RGT.Services.Core.DTO
{
    public class Branding
    {
        public string EventThumbnail { get; set; }
        public string Billboard01 { get; set; }
        public string Billboard02 { get; set; }
        public string Billboard03 { get; set; }
        public string Fence01 { get; set; }
        public string Fence02 { get; set; }
        public string Fence03 { get; set; }
        public string Fence04 { get; set; }
        public string Fence05 { get; set; }
        public string Fence06 { get; set; }
        public string Flag01 { get; set; }
        public string Flag02 { get; set; }
        public string Flag03 { get; set; }
        public string GateMainTop { get; set; }
        public string GateMainSide { get; set; }
        public string Decal01 { get; set; }
        public string Decal02 { get; set; }
        public string SignDistance { get; set; }
        public string TentBasicTop { get; set; }
        public string TentBasicWall { get; set; }
        public string TentTechTop { get; set; }
        public string TentTechWall { get; set; }
        public string GateSegmentTop { get; set; }
        public string GateSegmentSide { get; set; }


        public void Validate()
        {
            ValidateFile(EventThumbnail);
            ValidateFile(Billboard01);
            ValidateFile(Billboard02);
            ValidateFile(Billboard03);
            ValidateFile(Fence01);
            ValidateFile(Fence02);
            ValidateFile(Fence03);
            ValidateFile(Fence04);
            ValidateFile(Fence05);
            ValidateFile(Fence06);
            ValidateFile(Flag01);
            ValidateFile(Flag02);
            ValidateFile(Flag03);
            ValidateFile(GateMainTop);
            ValidateFile(GateMainSide);
            ValidateFile(Decal01);
            ValidateFile(Decal02);
            ValidateFile(SignDistance);
            ValidateFile(TentBasicTop);
            ValidateFile(TentBasicWall);
            ValidateFile(TentTechTop);
            ValidateFile(TentTechWall);
            ValidateFile(GateSegmentTop);
            ValidateFile(GateSegmentSide);
        }

        private void ValidateFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return;
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Branding file at '{filePath}' not found");
            }
        }
    }
}
