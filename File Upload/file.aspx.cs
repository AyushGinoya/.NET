using System;
using System.IO;

namespace File_Upload
{
    public partial class file : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if( FileUpload1.HasFile )
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string ext = Path.GetExtension(fileName).ToLower();

                if( ext == ".jpg" || ext == ".jpeg" || ext == ".png" )
                {
                    if( FileUpload1.PostedFile.ContentLength < 1536000 ) // 1.5MB
                    {
                        string saveDir = Server.MapPath("~/images/");

                        if( !Directory.Exists(saveDir) )
                        {
                            Directory.CreateDirectory(saveDir);
                        }

                        string savePath = Path.Combine(saveDir, fileName);
                        FileUpload1.PostedFile.SaveAs(savePath);

                        Response.Write("File uploaded successfully.");
                    }
                    else
                    {
                        Response.Write("Image size must be less than 1500 KB.");
                    }
                }
                else
                {
                    Response.Write("Please upload a .jpg, .jpeg, or .png file.");
                }
            }
            else
            {
                Response.Write("Please select a file first.");
            }
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string filepath = "~/images/LOGO.png";

            FileInfo file = new FileInfo(Server.MapPath(filepath));

            if( file.Exists )
            {
                file.Delete();
                Response.Write("File deleted successfully.");
            }
            else
            {
                Response.Write("File not found.");
            }
        }
    }
}