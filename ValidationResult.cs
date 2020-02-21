using System.ComponentModel.DataAnnotations.Schema;

namespace MedalynxAPI {
    [NotMapped]
    public class ValidationResult {
        public ValidationResult (){}
        public ValidationResult(string source, string message) {
            this.Source = source;
            this.Message = message;
        }
        public string Source {get; set; }
        public string Message {get; set; }
    }
}