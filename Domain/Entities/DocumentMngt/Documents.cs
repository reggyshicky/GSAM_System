namespace Domain.Entities.DocumentMngt
{
    public class Documents
    {
        public int Id { get; set; }
               
        public string FileName { get; set; } = string.Empty;

        public string AccountName { get; set; }= string.Empty;

        public string Folder {  get; set; } = string.Empty; 
        public string FileType { get; set; } = string.Empty;
        public string FileExtension { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string LoanAccount { get; set; }= string.Empty;

        public string Comments { get; set; } = string.Empty;


        public DateTime CreatedOn { get; set; }

        public string? ModifiedBy { get; set; }
        public char ModifiedFlag { get; set; } = 'N';
        public DateTime ModifiedTime { get; set; }

        public string? VerifiedBy { get; set; }
        public char VerifiedFlag { get; set; } = 'N';

        public string? UploadedBy { get; set; }  
        public DateTime UploadedTime { get; set; }  

        public DateTime VerifiedTime { get; set; }

        public string? DeletedBy { get; set; }
        public char DeletedFlag { get; set; } = 'N';
        public DateTime DeletedTime { get; set; }

        public char RejectedFlag { get; set; } = 'N';
        public string? RejectedBy { get; set; }
        public DateTime RejectedTime { get; set; }

       
    }
}

