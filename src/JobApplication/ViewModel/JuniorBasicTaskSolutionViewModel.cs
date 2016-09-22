using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplication.ViewModel
{
    public class JuniorBasicTaskSolutionViewModel
    {
        #region Properties
        [Required]
        public Guid Guid { get; set; }
        [Required]
        public string[] FizBuzz { get; set; }
        [Required]
        public int[] Sort { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string B64CV { get; set; }
        [Required]
        public string SourceCodeRepository { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            var viewModelStirngBulder = new StringBuilder();


            viewModelStirngBulder.Append($"{Environment.NewLine}Task1SolutionViewModel{Environment.NewLine}");
            viewModelStirngBulder.Append($"Guid: {this.Guid} {Environment.NewLine}");
            viewModelStirngBulder.Append($"Email: {this.Email} {Environment.NewLine}");
            viewModelStirngBulder.Append($"SourceCodeRepository: {this.SourceCodeRepository} {Environment.NewLine}");
            viewModelStirngBulder.Append("FizBuzz: ");
            for (int i = 0; i< this.FizBuzz.Length;i++)
            {
                viewModelStirngBulder.Append(this.FizBuzz[i]);
                if(i < this.FizBuzz.Length - 1)
                    viewModelStirngBulder.Append(",");
            }
            viewModelStirngBulder.Append(Environment.NewLine);
            viewModelStirngBulder.Append("Sort: ");
            for (int i = 0; i < this.Sort.Length; i++)
            {
                viewModelStirngBulder.Append(this.Sort[i]);
                if (i < this.Sort.Length - 1)
                    viewModelStirngBulder.Append(",");
            }
            viewModelStirngBulder.Append(Environment.NewLine);

            return viewModelStirngBulder.ToString();
        }
        #endregion
    }
}
