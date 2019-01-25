using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//tile:6,6 tile区域上边缘到顶部32， 下边缘到底部36， 左边缘到左边50左右， 右边缘到右边25左右；

namespace GithubContributionIllusion
{
    public static class Class1
    {
        public static void Main()
        {
            ConfigurationForm form = new ConfigurationForm();
            Application.Run(form);
        }
    }
}
