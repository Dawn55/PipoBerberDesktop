using MaterialSkin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipoBerberDesktop.Helpers
{
    public static class MaterialSkinManager
    {
        public static void ApplyMaterialSkin(MaterialSkin.Controls.MaterialForm form)
        {
            var materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(form);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Grey800,      
                Primary.Grey600,       
                Primary.Grey300,
                Accent.DeepPurple400,        
                TextShade.WHITE
            );
        }
    }
}
