using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace File_Upload
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string s = FileUpload1.PostedFile.FileName.ToString();
                int idx = s.LastIndexOf(".");
                string ext = s.Substring(idx + 1);
                //string s = FileUpload1.FileName.ToString();
                //string ext = Path.GetExtension(s).ToString();

                //(ext == “.png” || ext == ".jpg" || ext == ".jpeg"

                if (FileUpload1.PostedFile.ContentLength < 1536000) //1500 * 1024
                {
                    if (FileUpload1.PostedFile.ContentType == "image/jpeg" ||
                        FileUpload1.PostedFile.ContentType == "image/png" ||
                        FileUpload1.PostedFile.ContentType == "image/jpg")
                    {
                        //FileUpload1.PostedFile.SaveAs(s);
                        string saveDir = Server.MapPath("~/images/");
                        if (!Directory.Exists(saveDir))
                        {
                            Directory.CreateDirectory(saveDir);
                        }
                        string savePath = Path.Combine(saveDir, s);
                        FileUpload1.PostedFile.SaveAs(savePath);
                        Response.Write("File uploaded successfully.");
                    }
                    else
                    {
                        Response.Write("please upload jpeg or png file ");
                    }
                }
                else
                {
                    Response.Write("image size must be less than 1500 kilo bytes");
                }
            }
            else
            {
                Response.Write("Please select file first");
            }


        }
    }
}