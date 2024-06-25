using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.FileManagement.Dtos
{
    public record DocumentResponseDto ( string FileName,
                                        int Id,
                                        string AccountName,
                                        string Folder,
                                     string FileType,
                                     string FileExtension,
                                     string FilePath,
                                     string LoanAccount,
                                     DateTime CreatedOn,
                                     string UploadedBy,
                                     string Comments,
                                     char VerifiedFlag ='N'
                                     
        );
    
    
}
