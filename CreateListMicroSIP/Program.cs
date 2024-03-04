
using CreateListMicroSIP.Entities;

namespace CreateListMIcroSIP {
    class Program {
        static void Main(string[] args) {
            string path = @"C:\Users\NOT170\Downloads\lista de ramais 040324.csv";
            string destiny = @"C:\Users\NOT170\Downloads\Contatos do MicroSIP 2024-03-04.csv";


            List<ContactMicroSIP> contactsMicroSIP = new List<ContactMicroSIP>();
            List<String[]> lines = new List<String[]>();

            try {

                using (StreamReader rd = File.OpenText(path)) {
                    while (!rd.EndOfStream) {
                        lines.Add(rd.ReadLine().Split(','));
                    }

                    foreach (string[] line in lines) {
                        if (line[6] == "categories") continue;
                        if (line[8] == "default_address") continue;
                        if (line[11] == "display-name") continue;

                        contactsMicroSIP.Add(
                            new ContactMicroSIP(
                                line[6].Trim().Replace("\"", "")
                                + " || "
                                + line[11].Trim().Replace("\"", ""),
                                $"{line[8].Substring(5, 3)}"
                                )
                            );
                    }
                }

                using (StreamWriter sw = File.CreateText(destiny)) {

                    sw.WriteLine("name,number,First Name,Last Name,Phone Number,Mobile Number,E-mail Address,AddressCity,State,Postal Code,Comment,Id,Info,Presence,Directory");
                    foreach (ContactMicroSIP emp in contactsMicroSIP) {
                        sw.WriteLine($"{emp.Name},{emp.Number},,,,,,,,,,,,1,1");
                    }
                }

            }
            catch (IOException error) {
                Console.WriteLine(error.ToString());
            }
        }
    }
}
