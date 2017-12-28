using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Redsoft;

namespace DW2Winform
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtLoad.Text = "";
            txtDesigner.Text = "";
            StreamReader sr = new StreamReader(txtFileName.Text, Encoding.Default);
            String line;
            int i = 1;
            StringBuilder sb = new StringBuilder();
            string SqlName = "";
            string IdDataType = "";
            if (optFreeForm.Checked)
            {
                Dictionary<string, Column> dicCols = new Dictionary<string, Column>();
                string lastLine = "";
                bool hasNext = false;
                string ColumnsDefine = "";
                string NewColumns = "";
                string AddColumns = "";
                string ColumnsProperty = "";
                string sql = "";
                bool sqlLine = false;
                string className = System.IO.Path.GetFileNameWithoutExtension(txtFileName.Text);
                string lastCompute = "";
                bool hasNextCompute = false;
                List<NameValue> listArgs = new List<NameValue>();
                string updatewhere = "";
                string updatekeyinplace = "";
                string IdCol = "";
                string TableName = "";
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("updatewhere"))
                    {
                        updatewhere = GetValue(line,"updatewhere");
                        TableName = GetString(line, "update");
                    }
                    if (line.Contains("updatekeyinplace"))
                    {
                        updatekeyinplace = GetValue(line, "updatekeyinplace");
                    }

                    if (line.Contains("retrieve=\"") || sqlLine)
                    {
                        //提取SQL
                        sqlLine = true;
                        if (line.Contains("retrieve=\""))
                        {
                            sql += line.Substring(11);
                        }
                        else
                        {
                            if (line.Contains("\""))
                            {
                                sql += line.Substring(0, line.IndexOf("\""));
                                sqlLine = false;
                            }
                            else
                                sql += line;
                        }
                    }
                    if (line.Contains("arguments=("))
                    {
                        //提取参数
                        string arg = line.Substring(line.IndexOf("arguments=(") + 11);
                        arg = arg.Replace("(","").Replace(")","").Replace("\"", "");
                        string[] args=arg.Split(',');
                        for (int j = 0; j < args.Length;j++ )
                        {
                            NameValue nv = new NameValue();
                            nv.Name = args[j].Trim();
                            j++;
                            nv.Value = args[j].Trim();
                            listArgs.Add(nv);
                        }
                    }
                    if (line.Contains("column=(type="))
                    {
                        string name = GetName(line);
                        if (line.Contains("update=yes"))
                        {
                            ColumnsProperty += "\r\n  " + name + ".AllowUpdate = \"1\";";
                        }
                        else
                            ColumnsProperty += "\r\n  " + name + ".AllowUpdate = \"0\";";
                        if (GetValue(line, "key") == "yes")
                        {
                            IdCol = name;
                            SqlName = GetString(line, "dbname");
                            IdDataType = GetValue(line,"type");
                        }
                        if (!dicCols.ContainsKey(name))
                        {
                            Column col = new Column();
                            col.Name = name;
                            col.ColType = GetValue(line, "type");
                            if (GetValue(line, "key") == "yes")
                            {
                                col.KeyCol = true;
                                
                            }
                            if (line.Contains("update=yes"))
                                col.AllowUpdate = "1";
                            else
                                col.AllowUpdate = "0";
                            dicCols.Add(name, col);
                        }
                    }
                    if (line.Contains("column=(type=") && line.Contains("values=\""))
                    {
                        StringBuilder sbLoad = new StringBuilder();
                        //combox控件formload事件
                        string value = GetString(line, "values");
                        string name = GetName(line);
                        string[] values = value.Split('/');

                        sbLoad.Append("\r\n             DataTable " + name + "_list = new DataTable();");
                        sbLoad.Append("\r\n             " + name + "_list.Columns.Add(\"Name\");");
                        sbLoad.Append("\r\n             " + name + "_list.Columns.Add(\"Value\");");
                        foreach (string v in values)
                        {
                            string[] vn = Regex.Split(v, "\t", RegexOptions.IgnoreCase);
                            if (vn.Length == 2)
                                sbLoad.Append("\r\n             " + name + "_list.Rows.Add(\"" + vn[0].Trim() + "\", \"" + vn[1].Trim() + "\");");
                            
                            
                        }
                        sbLoad.Append("\r\n             Common.InitDDLB(" + name + "," + name + "_list);");
                        
                        txtLoad.Text +="\r\n            "+ sbLoad.ToString();

                    }
                    if (line.Contains("line(band=detail"))
                    {
                        string text = "";
                        string name = "";
                        decimal x = 0;
                        decimal y = 0;
                        decimal width = 0;
                        decimal height = 0;
                        string fontName = GetString(line, "font.face");
                        string fontSize = GetString(line, "font.height").Replace("-", "");
                        string fontWeight = GetString(line, "font.weight");
                        if (fontWeight == "700")
                            fontWeight = "Bold";
                        else
                            fontWeight = "Regular";
                        decimal rate1 = (decimal)4;
                        decimal rate2 = (decimal)3.3;
                        name = GetName(line);
                        text = GetString(line, "text");
                        x = Math.Floor(decimal.Parse(GetString(line, "x1")) / rate1);
                        y = Math.Floor(decimal.Parse(GetString(line, "y1")) / rate2);
                        width = Math.Floor(decimal.Parse(GetString(line, "x2")) / rate1)-
                            Math.Floor(decimal.Parse(GetString(line, "x1")) / rate1);
                        height = 2;
                        ColumnsDefine += "\r\n System.Windows.Forms.Panel " + name + ";";
                        NewColumns += "\r\n this." + name + "=new System.Windows.Forms.Panel();";
                        sb.Append("\r\n System.Windows.Forms.Label " + name + "=new System.Windows.Forms.Label();");
                        ColumnsProperty += "\r\n " + name + ".Location = new System.Drawing.Point(" + x + ", " + y + ");";
                        ColumnsProperty += "\r\n  " + name + ".Name = \"" + name + "\";";
                        //if (height < 26)
                        //    sb.Append("\r\n  " + name + ".AutoSize = true;");
                        string color = GetString(line, "pen.color");
                        if (color != "0")
                        {
                            if (color.Contains("~"))
                            {
                                color = color.Substring(0, color.IndexOf("~"));
                                color = "ColorTranslator.FromWin32(" + color + ")";
                            }
                            else
                                color = "ColorTranslator.FromWin32(" + color + ") ";
                            ColumnsProperty += "\r\n  " + name + ".BackColor =" + color + ";";
                        }
                        
                        ColumnsProperty += "\r\n  " + name + ".Size = new System.Drawing.Size(" + width + ", " + height + ");";
                        ColumnsProperty += "\r\n  " + name + ".Text = \"" + text + "\";";
                        
                        string visible = GetString(line, "visible");
                        if (visible == "1")
                            visible = "true";
                        else
                            visible = "false";
                        ColumnsProperty += "\r\n  " + name + ".Visible = " + visible + ";";
                        ColumnsProperty += "\r\n  " + name + ".Text = \"" + text + "\";";
                        
                        AddColumns += "\r\n  this.panel1.Controls.Add(" + name + ");";
                        sb.Append("\r\n  ");

                    }
                    if (line.Contains("text(band=detail") || hasNext)
                    {
                        if (line.Substring(line.Length - 2) != " )")
                        {
                            //没有闭合
                            hasNext = true;
                            if (lastLine == "")
                                lastLine = line;
                            else
                                lastLine = lastLine + "" + line;
                            continue;
                        }
                        else
                        {
                            line = lastLine+""+line;
                            hasNext = false;
                            lastLine = "";
                        }
                        string text = "";
                        string name = "";
                        decimal x = 0;
                        decimal y = 0;
                        decimal width = 0;
                        decimal height = 0;
                        string fontName = GetString(line, "font.face");
                        string fontSize = GetString(line, "font.height").Replace("-", "");
                        string fontWeight = GetString(line, "font.weight");
                        if (fontWeight == "700")
                            fontWeight = "Bold";
                        else
                            fontWeight = "Regular";
                        decimal rate1 = (decimal)4;
                        decimal rate2 = (decimal)3.3;
                        name = GetName(line);
                        text = GetString(line, "text");
                        x = Math.Floor(decimal.Parse(GetString(line, "x")) / rate1);
                        y = Math.Floor(decimal.Parse(GetString(line, "y")) / rate2);
                        width = Math.Floor(decimal.Parse(GetString(line, "width")) / rate1);
                        height = Math.Floor(decimal.Parse(GetString(line, "height")) / rate2);
                        ColumnsDefine += "\r\n System.Windows.Forms.Label " + name + ";";
                        NewColumns += "\r\n this." + name + "=new System.Windows.Forms.Label();";
                        sb.Append("\r\n System.Windows.Forms.Label " + name + "=new System.Windows.Forms.Label();");
                         ColumnsProperty+="\r\n " + name + ".Location = new System.Drawing.Point(" + x + ", " + y + ");";
                         ColumnsProperty+="\r\n  " + name + ".Name = \"" + name + "\";";
                        //if (height < 26)
                        //    sb.Append("\r\n  " + name + ".AutoSize = true;");
                        string color = GetString(line, "color");
                        if (color != "0")
                        {
                            if (color.Contains("~"))
                            {
                                color = color.Substring(0, color.IndexOf("~"));
                                color = "ColorTranslator.FromWin32(" + color + ")";
                            }
                            else
                                color = "ColorTranslator.FromWin32(" + color + ") ";
                             ColumnsProperty+="\r\n  " + name + ".ForeColor =" + color + ";";
                        }
                        color = GetString(line, "background.color");
                        if (color.Contains("~"))
                        {
                            color = color.Substring(0, color.IndexOf("~"));
                            color = "ColorTranslator.FromWin32(" + color + ")";
                            ColumnsProperty += "\r\n  " + name + ".BackColor = " + color + ";";
                        }
                        else if (color != "536870912" && color != "553648127")
                        {
                            ColumnsProperty += "\r\n  " + name + ".BackColor =  ColorTranslator.FromWin32(" + color + ");";
                        }
                         ColumnsProperty+="\r\n  " + name + ".TextAlign = ContentAlignment.MiddleRight;";
                         ColumnsProperty+="\r\n  " + name + ".Size = new System.Drawing.Size(" + width + ", " + height + ");";
                        ColumnsProperty+="\r\n  " + name + ".Text = \"" + text + "\";";
                         ColumnsProperty+="\r\n  " + name + ".Font = new System.Drawing.Font(\"" + fontName + "\", " + fontSize + "F, System.Drawing.FontStyle." + fontWeight + ", System.Drawing.GraphicsUnit.Point, ((byte)(134)));";
                        string visible = GetString(line, "visible");
                        if (visible == "1")
                            visible = "true";
                        else
                            visible = "false";
                         ColumnsProperty+="\r\n  " + name + ".Visible = " + visible + ";";
                         ColumnsProperty+="\r\n  " + name + ".Text = \"" + text + "\";";
                         string tag = GetString(line, "tag");
                         if (tag != "")
                             ColumnsProperty += "\r\n  " + name + ".Tag = \"" + tag + "\";";
                        string border=GetString(line,"border");
                        if (border=="2")
                            ColumnsProperty += "\r\n  " + name + ".BorderStyle =System.Windows.Forms.BorderStyle.FixedSingle;";
                        else if (border!="0")
                            ColumnsProperty += "\r\n  " + name + ".BorderStyle =System.Windows.Forms.BorderStyle.Fixed3D;";
                        AddColumns += "\r\n  this.panel1.Controls.Add(" + name + ");";
                        sb.Append("\r\n  ");
                        text = GetString(line, "text");
                        x = Math.Floor(decimal.Parse(GetString(line, "x")) / rate1);
                        y = Math.Floor(decimal.Parse(GetString(line, "y")) / rate2);
                        width = Math.Floor(decimal.Parse(GetString(line, "width")) / rate1);
                        height = Math.Floor(decimal.Parse(GetString(line, "height")) / rate2);
                        if (!dicCols.ContainsKey(name))
                        {
                            Column col = new Column();
                            col.Name = name;
                            dicCols.Add(name, col);
                        }
                        dicCols[name].X = (int)x;
                        dicCols[name].Width = (int)width;
                        dicCols[name].Text = text;
                        dicCols[name].Visible = GetString(line, "visible") == "1" ? true : false;
                        dicCols[name].Format = GetString(line, "format");
                        dicCols[name].Alignment = GetString(line, "alignment");
                        
                    }
                    if (line.Contains("column(band=detail") || line.Contains("compute(band=detail") || hasNextCompute)
                    {
                        if (line.Substring(line.Length - 2) != " )")
                        {
                            //没有闭合
                            hasNextCompute = true;
                            if (lastCompute == "")
                                lastCompute = line;
                            else
                                lastCompute = lastCompute + "" + line;
                            continue;
                        }
                        else
                        {
                            line = lastCompute + "" + line;
                            hasNextCompute = false;
                            lastCompute = "";
                        }
                        string name = "";
                        decimal x = 0;
                        decimal y = 0;
                        decimal width = 0;
                        decimal height = 0;
                        string fontName = GetString(line, "font.face");
                        string fontSize = GetString(line, "font.height").Replace("-", "");
                        string fontWeight = GetString(line, "font.weight");
                        if (fontWeight == "700")
                            fontWeight = "Bold";
                        else
                            fontWeight = "Regular";
                        decimal rate1 = (decimal)4;
                        decimal rate2 = (decimal)3.3;
                        name =  GetName(line);

                        x = Math.Floor(decimal.Parse(GetString(line, "x")) / rate1);
                        y = Math.Floor(decimal.Parse(GetString(line, "y")) / rate2);
                        width = Math.Floor(decimal.Parse(GetString(line, "width")) / rate1);
                        height = Math.Floor(decimal.Parse(GetString(line, "height")) / rate2);

                        string format = GetString(line, "format");
                        if (format.Contains("yyyy-mm-dd"))
                        {
                            ColumnsDefine += "\r\n Redsoft.MyDateTime " + name + ";";
                            NewColumns += "\r\n this." + name + "=new Redsoft.MyDateTime();";
                            sb.Append("\r\n Redsoft.MyDateTime " + name + "=new Redsoft.MyDateTime();");
                            if (format == "yyyy-mm-dd")
                                format = "0000-00-00";
                            if (format == "yyyy-mm-dd hh:mm:ss")
                                format = "0000-00-00 90:00:00";
                           ColumnsProperty+="\r\n  " + name + ".Mask = \"" + format + "\";";
                           string border = GetString(line, "border");
                           if (border == "2")
                               ColumnsProperty += "\r\n  " + name + ".BorderStyle =System.Windows.Forms.BorderStyle.FixedSingle;";
                           else if (border != "0")
                               ColumnsProperty += "\r\n  " + name + ".BorderStyle =System.Windows.Forms.BorderStyle.Fixed3D;";  
                        }
                        else
                            if (line.Contains("ddlb.allowedit") || line.Contains("dddw.limit"))
                            {
                                ColumnsDefine += "\r\n Redsoft.MyComboBox " + name + ";";
                                NewColumns += "\r\n this." + name + "=new Redsoft.MyComboBox();";
                                sb.Append("\r\n Redsoft.MyComboBox " + name + "=new Redsoft.MyComboBox();");
                            }
                            else if (line.Contains("radiobuttons.columns"))
                            {
                                ColumnsDefine += "\r\n Redsoft.MyOptions " + name + ";";
                                NewColumns += "\r\n this." + name + "=new Redsoft.MyOptions();";
                                ColumnsProperty += "\r\n  " + name + ".Columns=" + GetValue(line,"radiobuttons.columns") + ";";
                            }
                            else 
                            {
                                ColumnsDefine += "\r\n Redsoft.MyTextBox " + name + ";";
                                NewColumns += "\r\n this." + name + "=new Redsoft.MyTextBox();";
                                sb.Append("\r\n Redsoft.MyTextBox " + name + "=new Redsoft.MyTextBox();");
                                string border = GetString(line, "border");
                                if (border == "2")
                                    ColumnsProperty += "\r\n  " + name + ".BorderStyle =System.Windows.Forms.BorderStyle.FixedSingle;";
                                else if (border != "0")
                                    ColumnsProperty += "\r\n  " + name + ".BorderStyle =System.Windows.Forms.BorderStyle.Fixed3D;";

                            }
                        ColumnsProperty+="\r\n " + name + ".Location = new System.Drawing.Point(" + x + ", " + y + ");";
                       ColumnsProperty+="\r\n  " + name + ".Name = \"" + name + "\";";
                        if (height > 26)
                            ColumnsProperty+="\r\n  " + name + ".Multiline =true;";
                        ColumnsProperty += "\r\n  " + name + ".Size = new System.Drawing.Size(" + width + ", " + height + ");";
                        string tab = GetValue(line, "tabsequence");
                        if (tab != "")
                            ColumnsProperty += "\r\n " + name + ".TabIndex = " + tab + ";";
                        i++;
                       ColumnsProperty+="\r\n  " + name + ".Font = new System.Drawing.Font(\"" + fontName + "\", " + fontSize + "F, System.Drawing.FontStyle." + fontWeight + ", System.Drawing.GraphicsUnit.Point, ((byte)(134)));";
                        string color = GetString(line, "background.color");
                        if (color.Contains("~"))
                        {
                            color = color.Substring(0,color.IndexOf("~") );
                            color = "ColorTranslator.FromWin32(" + color + ")";
                            ColumnsProperty += "\r\n  " + name + ".BackColor = " + color + ";";
                        }
                        else
                        {
                            ColumnsProperty += "\r\n  " + name + ".BackColor =  ColorTranslator.FromWin32(" + color + ");";
                        }
                        if (line.Contains("edit.displayonly=yes") || GetString(line, "expression")!="")
                        {
                           ColumnsProperty+="\r\n  " + name + ".ReadOnly = true;";
                            ColumnsProperty+="\r\n  " + name + ".BackColor =  SystemColors.Control;";
                        }
                        string limit = GetValue(line, "edit.limit");
                        if (limit != "0" && limit!="")
                        {
                           ColumnsProperty+="\r\n  " + name + ".MaxLength = "+ limit+";";
                        }
                        string visible = GetString(line, "visible");
                        if (visible == "1")
                            visible = "true";
                        else
                            visible = "false";
                       ColumnsProperty+="\r\n  " + name + ".Visible = " + visible + ";";

                       string expression = GetString(line, "expression");
                       if (expression != "")
                           ColumnsProperty += "\r\n  " + name + ".Tag = \"" + expression + "\";";
                       string tag = GetString(line, "tag");
                       if (tag != "")
                           ColumnsProperty += "\r\n  " + name + ".Tag = \"" + tag + "\";";
                       AddColumns+="\r\n  this.panel1.Controls.Add(" + name + ");";
                        sb.Append("\r\n  ");
                        if (!dicCols.ContainsKey(name))
                        {
                            Column col = new Column();
                            col.Name = name;
                            dicCols.Add(name, col);
                        }
                        dicCols[name].Format = GetString(line, "format");
                        dicCols[name].Alignment = GetString(line, "alignment");
                        dicCols[name].DddwName = GetValue(line, "dddw.name");
                        dicCols[name].DddwDisplayCol = GetValue(line, "dddw.displaycolumn");
                        dicCols[name].DddwValueCol = GetValue(line, "dddw.datacolumn");
                        if (dicCols[name].DddwName != "")
                            dicCols[name].EditType = EditType.DDDW;
                        else if (line.Contains("radiobuttons"))
                            dicCols[name].EditType = EditType.RadioButtons;
                        else if (line.Contains("checkbox"))
                            dicCols[name].EditType = EditType.Checkbox;
                        else if (line.Contains(" ddlb."))
                            dicCols[name].EditType = EditType.DDLB;
                        else
                            dicCols[name].EditType = EditType.Edit;
                      
                       
                        dicCols[name].X = (int)x;
                        dicCols[name].Width = (int)width;
                     
                        dicCols[name].Visible = GetString(line, "visible") == "1" ? true : false;
                        dicCols[name].Format = GetString(line, "format");
                        dicCols[name].Alignment = GetString(line, "alignment");
                        dicCols[name].Id = GetValue(line, "id");
                    }
                    txtDesigner.Text = sb.ToString();
                }
                sql = sql.Replace("            ", "");
                //生成用户控件
                //复制资源文件
                string resxTemplate = Application.StartupPath + "\\Template.resx";
                string resx = txtTableDefinePath.Text + "\\" + className + ".resx";
                File.Copy(resxTemplate, resx, true);

                //designer文件
                string template = Application.StartupPath + "\\FreeFormTemplate.Designer.cs";
                string designerFile = txtTableDefinePath.Text + "\\" + className + ".Designer.cs";
                File.Copy(template, designerFile, true);
                string designer = string.Empty;
                
                using (FileStream fsdesigner = new FileStream(designerFile, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader srdesigner = new StreamReader(fsdesigner))
                    {
                        designer = srdesigner.ReadToEnd();
                        designer = designer.Replace("@ClassName", className);
                        
                        
                        designer = designer.Replace("@ColumnsDefine", ColumnsDefine);
                        designer = designer.Replace("@NewColumns", NewColumns);
                        
                        designer = designer.Replace("@AddColumns", AddColumns);
                        designer = designer.Replace("@ColumnsProperty", ColumnsProperty);
                    }
                }

                using (FileStream fsdesigner = new FileStream(designerFile, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter swdesigner = new StreamWriter(fsdesigner))
                    {
                        swdesigner.Write(designer);
                    }
                }

                //cs文件
                template = Application.StartupPath + "\\FreeFormTemplate.cs";
                designerFile = txtTableDefinePath.Text + "\\" + className + ".cs";
                File.Copy(template, designerFile, true);
                designer = string.Empty;

                using (FileStream fsdesigner = new FileStream(designerFile, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader srdesigner = new StreamReader(fsdesigner))
                    {
                        designer = srdesigner.ReadToEnd();
                        designer = designer.Replace("@ClassName", className);


                        designer = designer.Replace("@SQL", sql);
                        designer = designer.Replace("@FormLoad", txtLoad.Text);
                        string arguments = "";
                        for (int j = 0; j < listArgs.Count; j++)
                        {
                            arguments+="\r\n            result.Add(new NameValue(\"" + listArgs[j].Name + "\", \"" + listArgs[j].Value + "\"));";
                        }
                        designer = designer.Replace("@Arguments", arguments);
                        designer = designer.Replace("@updatewhere", updatewhere);
                        designer = designer.Replace("@updatekeyinplace", updatekeyinplace);
                        designer = designer.Replace("@IdCol", IdCol);
                        designer = designer.Replace("@TableName", TableName);
                        designer = designer.Replace("@SqlName", SqlName);
                        designer = designer.Replace("@IdDataType", IdDataType);
                        ColumnsDefine = "";
                        foreach (KeyValuePair<string, Column> kvp in dicCols)
                        {
                            ColumnsDefine += "\r\n             cols.Add(new Column(\"" + kvp.Value.Id + "\",\"" + kvp.Value.Name + "\",\"" + kvp.Value.Text + "\"," + kvp.Value.Visible.ToString().ToLower() + "," + kvp.Value.Width + "," + kvp.Value.X + ",\"" + kvp.Value.Alignment + "\",\"" + kvp.Value.ColType + "\"," + kvp.Value.KeyCol.ToString().ToLower() + ",\"" + kvp.Value.Expression + "\",\"" + kvp.Value.Format + "\"," + kvp.Value.ComputeCol.ToString().ToLower() + ",\"" + kvp.Value.DddwName + "\",\"" + kvp.Value.DddwDisplayCol + "\",\"" + kvp.Value.DddwValueCol + "\",EditType." + kvp.Value.EditType + ",\"" + kvp.Value.AllowUpdate + "\"));";

                        }
                        designer = designer.Replace("@ColumnsDefine", ColumnsDefine);
                    }
                }

                using (FileStream fsdesigner = new FileStream(designerFile, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter swdesigner = new StreamWriter(fsdesigner))
                    {
                        swdesigner.Write(designer);
                    }
                }

                

            }
            if (optGrid.Checked)
            {
                List<NameValue> listArgs = new List<NameValue>();
                string ColumnsDefine = "";
                string NewColumns = "";
                string AllColumns = "";
                string ColumnsProperty = "";
                decimal rate1 = (decimal)4;
                decimal rate2 = (decimal)3.3;
                string tableName = "";
                Dictionary<string,Column> dicCols=new Dictionary<string,Column>();
                string sql = "";
                bool sqlLine = false;
                string comboInit = "";
                string updatewhere = "";
                string updatekeyinplace = "";
                string IdCol = "";
                string TableName = "";
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("updatewhere"))
                    {
                        updatewhere = GetValue(line, "updatewhere");
                        TableName = GetString(line, "update");
                    }
                    if (line.Contains("updatekeyinplace"))
                    {
                        updatekeyinplace = GetValue(line, "updatekeyinplace");
                    }
                    if (tableName == "" && line.Contains("dbname"))
                    {
                       tableName= GetString(line, "dbname");
                       tableName = tableName.Substring(0, tableName.IndexOf('.'));
                    }
                    if (line.Contains("column=(type"))
                    {
                        string name = GetName(line);
                        string update = line.Contains("update=yes") ? "1" : "0";
                        if (!dicCols.ContainsKey(name))
                        {
                            Column col = new Column();
                            col.Name = name;
                            col.ColType = GetValue(line, "type");
                            if (GetValue(line, "key") == "yes")
                            {
                                col.KeyCol = true;
                                IdCol = name;
                                SqlName = GetString(line, "dbname");
                                IdDataType = GetValue(line, "type");
                            }
                            col.AllowUpdate = update;
                            dicCols.Add(name,col);
                        }

                    }
                    if (line.Contains("arguments=("))
                    {
                        //提取参数
                        string arg = line.Substring(line.IndexOf("arguments=(") + 11);
                        arg = arg.Replace("(", "").Replace(")", "").Replace("\"", "");
                        string[] args = arg.Split(',');
                        for (int j = 0; j < args.Length; j++)
                        {
                            NameValue nv = new NameValue();
                            nv.Name = args[j].Trim();
                            j++;
                            nv.Value = args[j].Trim();
                            listArgs.Add(nv);
                        }
                    }
                    if (line.Contains("text(band=header"))
                    {
                        string text = "";
                        string name = "";
                        decimal x = 0;
                        decimal y = 0;
                        decimal width = 0;
                        decimal height = 0;
                        string fontName = GetString(line, "font.face");
                        string fontSize = GetString(line, "font.height").Replace("-", "");
                        string fontWeight = GetString(line, "font.weight");
                        if (fontWeight == "700")
                            fontWeight = "Bold";
                        else
                            fontWeight = "Regular";
                        
                        name = GetName(line);
                        name = name.Substring(0, name.Length - 2);
                        text = GetString(line, "text");
                        x = Math.Floor(decimal.Parse(GetString(line, "x")) / rate1);
                        y = Math.Floor(decimal.Parse(GetString(line, "y")) / rate2);
                        width = Math.Floor(decimal.Parse(GetString(line, "width")) / rate1);
                        height = Math.Floor(decimal.Parse(GetString(line, "height")) / rate2);
                        if (!dicCols.ContainsKey(name))
                        {
                            Column col = new Column();
                            col.Name = name;
                            dicCols.Add(name, col);
                        }
                        dicCols[name].X = (int)x;
                        dicCols[name].Width = (int)width;
                        dicCols[name].Text = text;
                        dicCols[name].Visible = GetString(line, "visible") == "1" ? true : false;
                        dicCols[name].Format = GetString(line, "format");
                        dicCols[name].Alignment = GetString(line, "alignment");
                        //sb.Append("\r\n             cols.Add(\"" + name.ToLower() + "\", \"" + text + "\");");


                    }
                    if (line.Contains("column(band=detail"))
                    {
                        string name = GetName(line);
                        if (!dicCols.ContainsKey(name))
                        {
                            Column col = new Column();
                            col.Name = name;
                            dicCols.Add(name, col);
                        }
                        dicCols[name].Id = GetValue(line, "id");
                        dicCols[name].Format = GetString(line, "format");
                        dicCols[name].Alignment = GetString(line, "alignment");
                        dicCols[name].DddwName = GetValue(line, "dddw.name");
                        dicCols[name].DddwDisplayCol = GetValue(line, "dddw.displaycolumn");
                        dicCols[name].DddwValueCol = GetValue(line, "dddw.datacolumn");
                        if (dicCols[name].DddwName != "")
                            dicCols[name].EditType = EditType.DDDW;
                        else if (line.Contains("radiobuttons"))
                            dicCols[name].EditType = EditType.RadioButtons;
                        else if (line.Contains("checkbox"))
                            dicCols[name].EditType = EditType.Checkbox;
                        else if (line.Contains(" ddlb."))
                            dicCols[name].EditType = EditType.DDLB;
                        else
                            dicCols[name].EditType = EditType.Edit;
                        string tag = GetString(line, "tag");
                        if (tag != "")
                            ColumnsProperty += "\r\n  " + name + ".Tag = \"" + tag + "\";";
                        if (dicCols[name].Visible)
                        {
                            string color = GetString(line, "background.color");
                            if (color.Contains("~"))
                            {
                                color = color.Substring(0, color.IndexOf("~"));
                                color = "ColorTranslator.FromWin32(" + color + ")";

                                ColumnsProperty += "\r\n  " + name + ".DefaultCellStyle.BackColor = " + color + ";";
                            }
                            else if (color == "553648127" || color == "536870912")
                            {
                                ColumnsProperty += "\r\n  " + name + ".DefaultCellStyle.BackColor =  SystemColors.Control;";

                            }
                            else
                                ColumnsProperty += "\r\n  " + name + ".DefaultCellStyle.BackColor =  ColorTranslator.FromWin32(" + color + ");";
                        }
                    }
                    if (line.Contains("compute(band=summary"))
                    {
                        string name = GetName(line);
                        if (!dicCols.ContainsKey(name))
                        {
                            Column col = new Column();
                            col.Name = name;
                            dicCols.Add(name, col);
                        }
                        decimal x = Math.Floor(decimal.Parse(GetString(line, "x")) / rate1);
                        dicCols[name].X = (int)x;
                        dicCols[name].Alignment = GetString(line, "alignment");
                        dicCols[name].Expression = GetString(line, "expression");
                        dicCols[name].Format = GetString(line, "format");
                        dicCols[name].KeyCol = true;
                    }
                    if (line.Contains("retrieve=\"") || sqlLine)
                    {
                        //提取SQL
                        sqlLine = true;
                        if (line.Contains("retrieve=\""))
                        {
                            sql += line.Substring(11);
                        }
                        else
                        {
                            if (line.Contains("\""))
                            {
                                sql += line.Substring(0, line.IndexOf("\""));
                                sqlLine = false;
                            }
                            else
                                sql += line;
                        }
                    }
                    //下拉框的初始化
                    if (line.Contains("column=(type=") && line.Contains("values=\""))
                    {
                        StringBuilder sbLoad = new StringBuilder();
                        //combox控件formload事件
                        string value = GetString(line, "values");
                        string name = GetName(line);
                        string[] values = value.Split('/');

                        sbLoad.Append("\r\n             DataTable " + name + "_list = new DataTable();");
                        sbLoad.Append("\r\n             " + name + "_list.Columns.Add(\"Name\");");
                        sbLoad.Append("\r\n             " + name + "_list.Columns.Add(\"Value\");");
                        foreach (string v in values)
                        {
                            string[] vn = Regex.Split(v, "\t", RegexOptions.IgnoreCase);
                            if (vn.Length == 2)
                                sbLoad.Append("\r\n             " + name + "_list.Rows.Add(\"" + vn[0].Trim() + "\", \"" + vn[1].Trim() + "\");");


                        }
                        sbLoad.Append("\r\n             Common.InitDataGridViewColumn(dataGridView1.Columns[\"" + name + "\"], " + name + "_list);");

                        comboInit += "\r\n" + sbLoad.ToString();
                    }
                }
                sql = sql.Replace("            ", "");
                
                //cs文件
                string className = System.IO.Path.GetFileNameWithoutExtension(txtFileName.Text);
                string template = Application.StartupPath + "\\GridTemplate.cs";
                string designerFile = txtTableDefinePath.Text + "\\" + className + ".cs";
                File.Copy(template, designerFile, true);
                string designer = string.Empty;

                using (FileStream fsdesigner = new FileStream(designerFile, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader srdesigner = new StreamReader(fsdesigner))
                    {
                        designer = srdesigner.ReadToEnd();
                        designer = designer.Replace("@ClassName", className);


                        designer = designer.Replace("@SQL", sql);
                        designer = designer.Replace("@FormLoad", comboInit);
                        ColumnsDefine = "";
                        foreach (KeyValuePair<string, Column> kvp in dicCols)
                        {
                            ColumnsDefine += "\r\n             cols.Add(new Column(\"" + kvp.Value.Id + "\",\"" + kvp.Value.Name + "\",\"" + kvp.Value.Text + "\"," + kvp.Value.Visible.ToString().ToLower() + "," + kvp.Value.Width + "," + kvp.Value.X + ",\"" + kvp.Value.Alignment + "\",\"" + kvp.Value.ColType + "\"," + kvp.Value.KeyCol.ToString().ToLower() + ",\"" + kvp.Value.Expression + "\",\"" + kvp.Value.Format + "\"," + kvp.Value.ComputeCol.ToString().ToLower() + ",\"" + kvp.Value.DddwName + "\",\"" + kvp.Value.DddwDisplayCol + "\",\"" + kvp.Value.DddwValueCol + "\",EditType." + kvp.Value.EditType + ",\"" + kvp.Value.AllowUpdate + "\"));";

                        }

                        designer = designer.Replace("@ColumnsDefine", ColumnsDefine);
                        designer = designer.Replace("@updatewhere", updatewhere);
                        designer = designer.Replace("@updatekeyinplace", updatekeyinplace);
                        designer = designer.Replace("@IdCol", IdCol);
                        designer = designer.Replace("@TableName", TableName);
                        designer = designer.Replace("@SqlName", SqlName);
                        designer = designer.Replace("@IdDataType", IdDataType);
                        string arguments = "";
                        for (int j = 0; j < listArgs.Count; j++)
                        {
                            arguments += "\r\n            result.Add(new NameValue(\"" + listArgs[j].Name + "\", \"" + listArgs[j].Value + "\"));";
                        }
                        designer = designer.Replace("@Arguments", arguments);
                    }
                }

                using (FileStream fsdesigner = new FileStream(designerFile, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter swdesigner = new StreamWriter(fsdesigner))
                    {
                        swdesigner.Write(designer);
                    }
                }

               
                //生成设计器文件
                 template = Application.StartupPath + "\\GridTemplate.Designer.cs";
                 designerFile = txtTableDefinePath.Text + "\\" + className + ".Designer.cs";
                File.Copy(template, designerFile,true);
                 designer = string.Empty;
                List<Column> list = new List<Column>();
                foreach (KeyValuePair<string, Column> kvp in dicCols)
                {
                    if (kvp.Value.Visible)
                        list.Add(kvp.Value);
                }
                list.Sort(delegate(Column a, Column b)
                {
                    return a.X.CompareTo(b.X);
                });
                using (FileStream fsdesigner = new FileStream(designerFile, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader srdesigner = new StreamReader(fsdesigner))
                    {
                        designer = srdesigner.ReadToEnd();
                        designer = designer.Replace("@ClassName",className);
                        ColumnsDefine = "";
                        foreach (Column col in list)
                        {
                            string type = "DataGridViewTextBoxColumn";
                            if (col.EditType == EditType.Checkbox)
                                type = "DataGridViewCheckBoxColumn";
                            if (col.EditType == EditType.DDLB ||
                                col.EditType == EditType.DDDW ||
                                col.EditType == EditType.RadioButtons)
                                type = "DataGridViewComboBoxColumn";
                            string define = "private System.Windows.Forms." + type + " " + col.Name + ";";
                            ColumnsDefine += "\r\n" + define;
                            string newcol = "this." + col.Name + " = new System.Windows.Forms." + type + "();";
                            NewColumns += "\r\n" + newcol;
                            AllColumns += "this." + col.Name + ",";

                            string property = "\r\nthis." + col.Name + ".HeaderText = \"" + col.Text + "\";";

                            property += "\r\nthis." + col.Name + ".Name = \"" + col.Name + "\";";
                            property += "\r\nthis." + col.Name + ".Width = " + col.Width + ";";
                             property += "\r\nthis." + col.Name + ".HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;";
                             string alignment = "";
                             if (col.Alignment == "0")
                                 alignment = "MiddleLeft";
                             if (col.Alignment == "1")
                                 alignment = "MiddleRight";
                             else
                                 alignment = "MiddleCenter";
                             property += "\r\nthis." + col.Name + ".DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment." + alignment + ";";
                             if (col.EditType == EditType.DDLB ||
                                 col.EditType == EditType.DDDW ||
                                 col.EditType == EditType.RadioButtons)
                             {
                                 property += "\r\nthis." + col.Name + ".DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;";
                                 
                             }
                             if (col.Format != "")
                                 property += "\r\nthis." + col.Name + ".DefaultCellStyle.Tag = \""+ col.Format +"\";";
                            ColumnsProperty += "\r\n" + property;
                            

                        }
                        designer = designer.Replace("@ColumnsDefine", ColumnsDefine);
                        designer = designer.Replace("@NewColumns", NewColumns);
                        AllColumns = AllColumns.Substring(0, AllColumns.Length - 1);
                        designer = designer.Replace("@AllColumns", AllColumns);
                        designer = designer.Replace("@ColumnsProperty", ColumnsProperty);
                    }
                }

                using (FileStream fsdesigner = new FileStream(designerFile, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter swdesigner = new StreamWriter(fsdesigner))
                    {
                        swdesigner.Write(designer);
                    }
                }
                //复制资源文件
                string resxTemplate = Application.StartupPath + "\\Template.resx";
                string resx = txtTableDefinePath.Text + "\\" + className + ".resx";
                File.Copy(resxTemplate, resx, true);
            }
        }
        private string GetString(string line, string key)
        {
            string result = "";
            int itext = line.IndexOf(" " + key + "=\"");
            if (itext < 0)
                return "";
            result = line.Substring(itext + key.Length + 3);
            result = result.Substring(0, result.IndexOf("\""));
            return result;
        }
        private string GetName(string line)
        {
            string key = "name";
            string result = "";
            int itext = line.IndexOf(" " + key + "=");
            result = line.Substring(itext + key.Length + 2);
            result = result.Substring(0, result.IndexOf(" "));
            return result;
        }
        private string GetValue(string line,string key)
        {
           
            string result = "";
            int itext = 0;
            if (key == "type")
                itext = line.IndexOf("" + key + "=");
            else
                itext = line.IndexOf(" " + key + "=");
            if (itext < 0)
                return "";
            if (key == "type")
                result = line.Substring(itext + key.Length + 1);
            else
                result = line.Substring(itext + key.Length + 2);
            result = result.Substring(0, result.IndexOf(" "));
            return result;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(ColorTranslator.ToWin32(Color.White).ToString());
            //ColorTranslator.FromWin32(123);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime t1=DateTime.Now;
            StringBuilder sb = new StringBuilder();
            for  (int i = 0; i < 1000000; i++)
            {  
                sb.Append("A." + i.ToString());
            }
            DateTime t2 = DateTime.Now;
            MessageBox.Show((t2 - t1).TotalMilliseconds.ToString());
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show(Color.FromArgb(220, 220, 220).Name);
            Color myColor = ColorTranslator.FromWin32(15263976);
                
            // Translate myColor to an OLE color.
            int winColor = ColorTranslator.ToWin32(myColor);

            // Show a message box with the value of winColor.
            MessageBox.Show(winColor.ToString());
        }
    }
}
