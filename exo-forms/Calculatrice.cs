using System;
using System.Windows.Forms;

namespace forms
{
  public partial class Calculatrice : Form
  {

    public Calculatrice()
    {
      InitializeComponent();
    }

    public void buttonNumber_Click(Object sender, EventArgs e)
    {
      var btn = (Button)sender;
      lblHistoCalc.Text += btn.Text;
    }

    public void buttonOp_Click(Object sender, EventArgs e)
    {
      var btn = (Button)sender;

      if (btn.Text != "=")
      {
        lblHistoCalc.Text += " " + btn.Text + " ";
      }
      else
      {
        Calc();
      }
    }

    private void buttonRemove_Click(object sender, EventArgs e)
    {
      if (lblHistoCalc.Text.Length > 0)
      {
        string txt = lblHistoCalc.Text;
        txt = txt.Remove(txt.Length - 1);
        lblHistoCalc.Text = txt;
      }
    }

    private void Calc()
    {
      string strCalc = lblHistoCalc.Text;
      string[] listOp = strCalc.Split(' ');
      double cur = Double.Parse(listOp[0]);

      for (int i = 0; i < listOp.Length; i++)
      {
        switch (listOp[i])
        {
          case "+":
            cur = cur + Double.Parse(listOp[i + 1]);
            break;
          case "-":
            cur = cur - Double.Parse(listOp[i + 1]);
            break;
          case "*":
            cur = cur * Double.Parse(listOp[i + 1]);
            break;
          case "/":
            cur = cur / Double.Parse(listOp[i + 1]);
            break;
          default:
            break;
        }
      }

      lblResult.Text = cur.ToString();
    }

    /// <summary>
    /// Réinitialise l'affichage.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonC_Click(object sender, EventArgs e)
    {
      lblHistoCalc.Text = "";
      lblResult.Text = "";
    }

    /// <summary>
    /// Rajoute une virgule à l'affichage.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonVirg_Click(object sender, EventArgs e)
    {
      lblHistoCalc.Text += ",";
    }
  }
}
