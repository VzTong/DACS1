using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

namespace MoviePJ.Extensions
{
    public static class SecurityExtensions
    {
        /// <summary>
        /// Đây là một phương thức mở rộng trong C# được sử dụng để loại bỏ các dấu diacritic (dấu thanh, dấu sắc, dấu huyền, v.v.) từ một chuỗi.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveAccents(this string text)
        {
            // Kiểm tra xem chuỗi có rỗng hoặc chỉ chứa khoảng trắng không
            if (string.IsNullOrWhiteSpace(text))
                return text;    // Nếu có, trả về nguyên chuỗi

            // Normalize được sử dụng để trả về một chuỗi mới mà biểu diễn nhị phân của nó tuân theo một dạng chuẩn hóa Unicode cụ thể.
            // FormD:(Canonical Decomposition): Phân tách các ký tự như ‘Ä’ thành ‘A’ và dấu mũ.
            // Sử dụng phương thức Normalize để chuyển đổi chuỗi sang dạng chuẩn hóa Unicode FormD,
            // nơi mà các ký tự được phân tách thành cơ bản và các dấu diacritic riêng biệt
            text = text.Normalize(NormalizationForm.FormD);

            // Lọc ra các ký tự không phải là dấu diacritic (NonSpacingMark)
            char[] chars = text
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c)
                != UnicodeCategory.NonSpacingMark).ToArray();

            // Tạo một chuỗi mới từ các ký tự đã lọc và chuẩn hóa lại nó về dạng FormC,
            // nơi mà các ký tự cơ bản và dấu diacritic được kết hợp lại nếu có thể
            return new string(chars).Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Đây là một phương thức mở rộng trong C# dùng để tạo ra một “slug” từ một chuỗi, thường được sử dụng trong các URL.
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string Slugify(this string phrase)
        {
            // Loại bỏ dấu diacritic và chuyển chuỗi thành chữ thường
            string output = phrase.RemoveAccents().ToLower();

            // Thay thế ký tự 'đ' bằng 'd'
            output = Regex.Replace(output, @"đ", "d");

            // Loại bỏ tất cả các ký tự không phải là chữ cái, số, khoảng trắng hoặc dấu gạch ngang
            output = Regex.Replace(output, @"[^A-Za-z0-9\s-]", "");

            // Thay thế một hoặc nhiều khoảng trắng liên tiếp bằng một khoảng trắng duy nhất
            output = Regex.Replace(output, @"\s+", " ").Trim();

            // Thay thế khoảng trắng bằng dấu gạch ngang
            output = Regex.Replace(output, @"\s", "-");
            return output;
        }
    }
}
