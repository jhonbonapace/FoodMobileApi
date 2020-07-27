using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class seedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Displayable = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    URL = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ContactType = table.Column<int>(nullable: false),
                    ProfileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Bacen", "Initials", "Name", "Name_PT" },
                values: new object[,]
                {
                    { 1, "1058", "BR", "Brazil", "Brasil" },
                    { 164, "5762", "PK", "Pakistan", "Paquistão" },
                    { 165, "5754", "PW", "Palau", "Palau" },
                    { 166, "5800", "PA", "Panama", "Panamá" },
                    { 167, "5452", "PG", "Papua New Guinea", "Papua Nova Guine" },
                    { 168, "5860", "PY", "Paraguay", "Paraguai" },
                    { 169, "5894", "PE", "Peru", "Peru" },
                    { 170, "2674", "PH", "Philippines", "Filipinas" },
                    { 171, "5932", "PN", "Pitcairn", "Pitcairn, Ilha" },
                    { 172, "6033", "PL", "Poland", "Polônia, Republica da" },
                    { 173, "6076", "PT", "Portugal", "Portugal" },
                    { 174, "6114", "PR", "Puerto Rico", "Porto Rico" },
                    { 175, "1546", "QA", "Qatar", "Catar" },
                    { 176, "6602", "RE", "Reunion", "Reunião, Ilha" },
                    { 177, "6700", "RO", "Romania", "Romênia" },
                    { 178, "6769", "RU", "Russian Federation", "Rússia, Federação da" },
                    { 179, "6750", "RW", "Rwanda", "Ruanda" },
                    { 180, "6955", "KN", "Saint Kitts and Nevis", "São Cristovão e Neves, Ilhas" },
                    { 181, "7153", "LC", "Saint LUCIA", "Santa Lucia" },
                    { 182, "7056", "VC", "Saint Vincent and the Grenadines", "São Vicente e Granadinas" },
                    { 183, "6904", "WS", "Samoa", "Samoa" },
                    { 184, "6971", "SM", "San Marino", "San Marino" },
                    { 185, "7200", "ST", "Sao Tome and Principe", "São Tome e Príncipe, Ilhas" },
                    { 186, "531", "SA", "Saudi Arabia", "Arábia Saudita" },
                    { 187, "7285", "SN", "Senegal", "Senegal" },
                    { 188, "7315", "SC", "Seychelles", "Seychelles" },
                    { 189, "7358", "SL", "Sierra Leone", "Serra Leoa" },
                    { 190, "7412", "SG", "Singapore", "Cingapura" },
                    { 163, "5568", "OM", "Oman", "Oma" },
                    { 162, "5380", "NO", "Norway", "Noruega" },
                    { 161, "4723", "MP", "Northern Mariana Islands", "Marianas do Norte" },
                    { 160, "5355", "NF", "Norfolk Island", "Norfolk, Ilha" },
                    { 131, "4553", "MY", "Malaysia", "Malásia" },
                    { 132, "4618", "MV", "Maldives", "Maldivas" },
                    { 133, "4642", "ML", "Mali", "Mali" },
                    { 134, "4677", "MT", "Malta", "Malta" },
                    { 135, "4766", "MH", "Marshall Islands", "Marshall, Ilhas" },
                    { 136, "4774", "MQ", "Martinique", "Martinica" },
                    { 137, "4880", "MR", "Mauritania", "Mauritânia" },
                    { 138, "4855", "MU", "Mauritius", "Mauricio" },
                    { 139, "4885", "YT", "Mayotte", "Mayotte (Ilhas Francesas)" },
                    { 140, "4936", "MX", "Mexico", "México" },
                    { 141, "4995", "FM", "Micronesia, Federated States of", "Micronesia" },
                    { 142, "4944", "MD", "Moldova, Republic of", "Moldávia, Republica da" },
                    { 143, "4952", "MC", "Monaco", "Mônaco" },
                    { 191, "2470", "SK", "Slovakia (Slovak Republic)", "Eslovaca, Republica" },
                    { 144, "4979", "MN", "Mongolia", "Mongólia" },
                    { 146, "4740", "MA", "Morocco", "Marrocos" },
                    { 147, "5053", "MZ", "Mozambique", "Moçambique" },
                    { 148, "930", "MM", "Myanmar", "Mianmar (Birmânia)" },
                    { 149, "5070", "NA", "Namibia", "Namíbia" },
                    { 150, "5088", "NR", "Nauru", "Nauru" },
                    { 151, "5177", "NP", "Nepal", "Nepal" },
                    { 152, "5738", "NL", "Netherlands", "Países Baixos (Holanda)" },
                    { 154, "5428", "NC", "New Caledonia", "Nova Caledonia" },
                    { 155, "5487", "NZ", "New Zealand", "Nova Zelândia" },
                    { 156, "5215", "NI", "Nicaragua", "Nicarágua" },
                    { 157, "5258", "NE", "Niger", "Níger" },
                    { 158, "5282", "NG", "Nigeria", "Nigéria" },
                    { 159, "5312", "NU", "Niue", "Niue, Ilha" },
                    { 145, "5010", "MS", "Montserrat", "Montserrat, Ilhas" },
                    { 192, "2461", "SI", "Slovenia", "Eslovênia, Republica da" },
                    { 193, "6777", "SB", "Solomon Islands", "Salomão, Ilhas" },
                    { 194, "7480", "SO", "Somalia", "Somalia" },
                    { 227, "8451", "UY", "Uruguay", "Uruguai" },
                    { 228, "8478", "UZ", "Uzbekistan", "Uzbequistão, Republica do" },
                    { 229, "5517", "VU", "Vanuatu", "Vanuatu" },
                    { 230, "8508", "VE", "Venezuela", "Venezuela" },
                    { 231, "8583", "VN", "Viet Nam", "Vietnã" },
                    { 232, "8630", "VG", "Virgin Islands (British)", "Virgens, Ilhas (Britânicas)" },
                    { 233, "8664", "VI", "Virgin Islands (U.S.)", "Virgens, Ilhas (E.U.A.)" },
                    { 234, "8753", "WF", "Wallis and Futuna Islands", "Wallis e Futuna, Ilhas" },
                    { 235, "6858", "EH", "Western Sahara", "Saara Ocidental" },
                    { 236, "3573", "YE", "Yemen", "Iémen" },
                    { 237, "3883", "YU", "Yugoslavia", "Iugoslávia, República Fed. da" },
                    { 238, "8907", "ZM", "Zambia", "Zâmbia" },
                    { 239, "6653", "ZW", "Zimbabwe", "Zimbabue" },
                    { 226, "18664", "UM", "United States Minor Outlying Islands", "Ilhas Menores Distantes dos Estados Unidos" },
                    { 240, "1504", "GG", "Bailiwick of Guernsey", "Guernsey, Ilha do Canal (Inclui Alderney e Sark)" },
                    { 243, "3595", "IM", "Isle of Man", "Man, Ilha de" },
                    { 246, "4985", "ME", "Crna Gora (Montenegro)", "Montenegro" },
                    { 247, "7370", "RS", "SÉRVIA", "Republika Srbija" },
                    { 248, "7600", "SS", "Republic of South Sudan", "Sudao do Sul" },
                    { 249, "8958", null, "Zona del Canal de Panamá", "Zona do Canal do Panamá" },
                    { 252, "5780", "PS", "Dawlat Filasṭīn", "Palestina" },
                    { 253, "153", "AX", "Åland Islands", "Aland, Ilhas" },
                    { 255, "200", "CW", "Curaçao", "Curaçao" },
                    { 256, "6998", "SM", "Saint Martin", "São Martinho, Ilha de (Parte Holandesa)" },
                    { 258, "990", "AN", "Bonaire", "Bonaire" },
                    { 259, "420", "AQ", "Antartica", "Antartica" },
                    { 260, "3433", "AU", "Heard Island and McDonald Islands", "Ilha Herad e Ilhas Macdonald" },
                    { 261, "6939", "FR", "Saint-Barthélemy", "São Bartolomeu" },
                    { 241, "1508", "JE", "Bailiwick of Jersey", "Jersey, Ilha do Canal" },
                    { 130, "4588", "MW", "Malawi", "Malavi" },
                    { 225, "2496", "US", "United States", "Estados Unidos" },
                    { 223, "2445", "AE", "United Arab Emirates", "Emirados Árabes Unidos" },
                    { 195, "7560", "ZA", "South Africa", "África do Sul" },
                    { 196, "2925", "GS", "South Georgia and the South Sandwich Islands", "Ilhas Geórgia do Sul e Sandwich do Sul" },
                    { 197, "2453", "ES", "Spain", "Espanha" },
                    { 198, "7501", "LK", "Sri Lanka", "Sri Lanka" },
                    { 199, "7102", "SH", "St. Helena", "Santa Helena" },
                    { 200, "7005", "PM", "St. Pierre and Miquelon", "São Pedro e Miquelon" },
                    { 201, "7595", "SD", "Sudan", "Sudão" },
                    { 202, "7706", "SR", "Suriname", "Suriname" },
                    { 203, "7552", "SJ", "Svalbard and Jan Mayen Islands", "Svalbard e Jan Mayen" },
                    { 204, "7544", "SZ", "Swaziland", "Eswatini" },
                    { 205, "7641", "SE", "Sweden", "Suécia" },
                    { 206, "7676", "CH", "Switzerland", "Suíça" },
                    { 207, "7447", "SY", "Syrian Arab Republic", "Síria, Republica Árabe da" },
                    { 224, "6289", "GB", "United Kingdom", "Reino Unido" },
                    { 208, "1619", "TW", "Taiwan, Province of China", "Formosa (Taiwan)" },
                    { 210, "7803", "TZ", "Tanzania, United Republic of", "Tanzânia, Republica Unida da" },
                    { 211, "7765", "TH", "Thailand", "Tailândia" },
                    { 212, "8001", "TG", "Togo", "Togo" },
                    { 213, "8052", "TK", "Tokelau", "Toquelau, Ilhas" },
                    { 214, "8109", "TO", "Tonga", "Tonga" },
                    { 215, "8150", "TT", "Trinidad and Tobago", "Trinidad e Tobago" },
                    { 216, "8206", "TN", "Tunisia", "Tunísia" },
                    { 217, "8273", "TR", "Turkey", "Turquia" },
                    { 218, "8249", "TM", "Turkmenistan", "Turcomenistão, Republica do" },
                    { 219, "8230", "TC", "Turks and Caicos Islands", "Turcas e Caicos, Ilhas" },
                    { 220, "8281", "TV", "Tuvalu", "Tuvalu" },
                    { 221, "8338", "UG", "Uganda", "Uganda" },
                    { 222, "8311", "UA", "Ukraine", "Ucrânia" },
                    { 209, "7722", "TJ", "Tajikistan", "Tadjiquistao, Republica do" },
                    { 129, "4502", "MG", "Madagascar", "Madagascar" },
                    { 128, "4499", "MK", "North Macedonia", "Macedônia do Norte" },
                    { 127, "4472", "MO", "Macau", "Macau" },
                    { 34, "310", "BF", "Burkina Faso", "Burkina Faso" },
                    { 35, "1155", "BI", "Burundi", "Burundi" },
                    { 36, "1414", "KH", "Cambodia", "Camboja" },
                    { 37, "1457", "CM", "Cameroon", "Camarões" },
                    { 38, "1490", "CA", "Canada", "Canada" },
                    { 39, "1279", "CV", "Cape Verde", "Cabo Verde, Republica de" },
                    { 40, "1376", "KY", "Cayman Islands", "Cayman, Ilhas" },
                    { 41, "6408", "CF", "Central African Republic", "Republica Centro-Africana" },
                    { 42, "7889", "TD", "Chad", "Chade" },
                    { 43, "1589", "CL", "Chile", "Chile" },
                    { 44, "1600", "CN", "China", "China, Republica Popular" },
                    { 45, "5118", "CX", "Christmas Island", "Christmas, Ilha (Navidad)" },
                    { 46, "1651", "CC", "Cocos (Keeling) Islands", "Cocos (Keeling), Ilhas" },
                    { 33, "1112", "BG", "Bulgaria", "Bulgária, Republica da" },
                    { 47, "1694", "CO", "Colombia", "Colômbia" },
                    { 49, "1775", "CG", "Congo", "Congo" },
                    { 50, "8885", "CD", "Congo, the Democratic Republic of the", "Congo, Republica Democrática do" },
                    { 51, "1830", "CK", "Cook Islands", "Cook, Ilhas" },
                    { 52, "1961", "CR", "Costa Rica", "Costa Rica" },
                    { 53, "1937", "CI", "Cote d`Ivoire", "Costa do Marfim" },
                    { 54, "1953", "HR", "Croatia (Hrvatska)", "Croácia (Republica da)" },
                    { 55, "1996", "CU", "Cuba", "Cuba" },
                    { 56, "1635", "CY", "Cyprus", "Chipre" },
                    { 57, "7919", "CZ", "Czech Republic", "Tcheca, Republica" },
                    { 58, "2321", "DK", "Denmark", "Dinamarca" },
                    { 59, "7838", "DJ", "Djibouti", "Djibuti" },
                    { 60, "2356", "DM", "Dominica", "Dominica, Ilha" },
                    { 61, "6475", "DO", "Dominican Republic", "Republica Dominicana" },
                    { 48, "1732", "KM", "Comoros", "Comores, Ilhas" },
                    { 62, "7951", "TL", "East Timor", "Timor Leste" },
                    { 32, "1082", "BN", "Brunei Darussalam", "Brunei" },
                    { 30, "1023", "BV", "Bouvet Island", "Bouvet, Ilha" },
                    { 2, "132", "AF", "Afghanistan", "Afeganistão" },
                    { 3, "175", "AL", "Albania", "Albânia, Republica da" },
                    { 4, "590", "DZ", "Algeria", "Argélia" },
                    { 5, "6912", "AS", "American Samoa", "Samoa Americana" },
                    { 6, "370", "AD", "Andorra", "Andorra" },
                    { 7, "400", "AO", "Angola", "Angola" },
                    { 8, "418", "AI", "Anguilla", "Anguilla" },
                    { 9, "3596", "AQ", "Antarctica", "Antártida" },
                    { 10, "434", "AG", "Antigua and Barbuda", "Antigua e Barbuda" },
                    { 11, "639", "AR", "Argentina", "Argentina" },
                    { 12, "647", "AM", "Armenia", "Armênia, Republica da" },
                    { 13, "655", "AW", "Aruba", "Aruba" },
                    { 14, "698", "AU", "Australia", "Austrália" },
                    { 31, "7820", "IO", "British Indian Ocean Territory", "Território Britânico do Oceano Indico" },
                    { 15, "728", "AT", "Austria", "Áustria" },
                    { 17, "779", "BS", "Bahamas", "Bahamas, Ilhas" },
                    { 18, "809", "BH", "Bahrain", "Bahrein, Ilhas" },
                    { 19, "817", "BD", "Bangladesh", "Bangladesh" },
                    { 20, "833", "BB", "Barbados", "Barbados" },
                    { 21, "850", "BY", "Belarus", "Belarus, Republica da" },
                    { 22, "876", "BE", "Belgium", "Bélgica" },
                    { 23, "884", "BZ", "Belize", "Belize" },
                    { 24, "2291", "BJ", "Benin", "Benin" },
                    { 25, "906", "BM", "Bermuda", "Bermudas" },
                    { 26, "1198", "BT", "Bhutan", "Butão" },
                    { 27, "973", "BO", "Bolivia", "Bolívia" },
                    { 28, "981", "BA", "Bosnia and Herzegowina", "Bósnia-herzegovina (Republica da)" },
                    { 29, "1015", "BW", "Botswana", "Botsuana" },
                    { 16, "736", "AZ", "Azerbaijan", "Azerbaijão, Republica do" },
                    { 262, "6980", "SM", "Saint Martin", "São Martinho, Ilha de (Parte Francesa)" },
                    { 63, "2399", "EC", "Ecuador", "Equador" },
                    { 65, "6874", "SV", "El Salvador", "El Salvador" },
                    { 99, "3557", "HU", "Hungary", "Hungria, Republica da" },
                    { 100, "3794", "IS", "Iceland", "Islândia" },
                    { 101, "3611", "IN", "India", "Índia" },
                    { 102, "3654", "ID", "Indonesia", "Indonésia" },
                    { 103, "3727", "IR", "Iran (Islamic Republic of)", "Ira, Republica Islâmica do" },
                    { 104, "3697", "IQ", "Iraq", "Iraque" },
                    { 105, "3751", "IE", "Ireland", "Irlanda" },
                    { 106, "3832", "IL", "Israel", "Israel" },
                    { 107, "3867", "IT", "Italy", "Itália" },
                    { 108, "3913", "JM", "Jamaica", "Jamaica" },
                    { 109, "3999", "JP", "Japan", "Japão" },
                    { 110, "4030", "JO", "Jordan", "Jordânia" },
                    { 111, "1538", "KZ", "Kazakhstan", "Cazaquistão, Republica do" },
                    { 98, "3514", "HK", "Hong Kong", "Hong Kong" },
                    { 112, "6238", "KE", "Kenya", "Quênia" },
                    { 114, "1872", "KP", "Korea, Democratic People`s Republic of", "Coreia, Republica Popular Democrática da" },
                    { 115, "1902", "KR", "Korea, Republic of", "Coreia, Republica da" },
                    { 116, "1988", "KW", "Kuwait", "Kuwait" },
                    { 117, "6254", "KG", "Kyrgyzstan", "Quirguiz, Republica" },
                    { 118, "4200", "LA", "Lao People`s Democratic Republic", "Laos, Republica Popular Democrática do" },
                    { 119, "4278", "LV", "Latvia", "Letônia, Republica da" },
                    { 120, "4316", "LB", "Lebanon", "Líbano" },
                    { 121, "4260", "LS", "Lesotho", "Lesoto" },
                    { 122, "4340", "LR", "Liberia", "Libéria" },
                    { 123, "4383", "LY", "Libyan Arab Jamahiriya", "Líbia" },
                    { 124, "4405", "LI", "Liechtenstein", "Liechtenstein" },
                    { 125, "4421", "LT", "Lithuania", "Lituânia, Republica da" },
                    { 126, "4456", "LU", "Luxembourg", "Luxemburgo" },
                    { 113, "4111", "KI", "Kiribati", "Kiribati" },
                    { 64, "2402", "EG", "Egypt", "Egito" },
                    { 97, "3450", "HN", "Honduras", "Honduras" },
                    { 95, "3603", "HM", "Heard and Mc Donald Islands", "Ilha Heard e Ilhas McDonald" },
                    { 66, "3310", "GQ", "Equatorial Guinea", "Guine-Equatorial" },
                    { 67, "2437", "ER", "Eritrea", "Eritreia" },
                    { 68, "2518", "EE", "Estonia", "Estônia, Republica da" },
                    { 69, "2534", "ET", "Ethiopia", "Etiópia" },
                    { 70, "2550", "FK", "Falkland Islands (Malvinas)", "Falkland (Ilhas Malvinas)" },
                    { 71, "2593", "FO", "Faroe Islands", "Feroe, Ilhas" },
                    { 72, "8702", "FJ", "Fiji", "Fiji" },
                    { 73, "2712", "FI", "Finland", "Finlândia" },
                    { 74, "2755", "FR", "France", "Franca" },
                    { 76, "3255", "GF", "French Guiana", "Guiana francesa" },
                    { 77, "5991", "PF", "French Polynesia", "Polinésia Francesa" },
                    { 78, "3607", "TF", "French Southern Territories", "Terras Austrais e Antárticas Francesas" },
                    { 79, "2810", "GA", "Gabon", "Gabão" },
                    { 96, "8486", "VA", "Holy See (Vatican City State)", "Vaticano, Estado da Cidade do" },
                    { 80, "2852", "GM", "Gambia", "Gambia" },
                    { 82, "230", "DE", "Germany", "Alemanha" },
                    { 83, "2895", "GH", "Ghana", "Gana" },
                    { 84, "2933", "GI", "Gibraltar", "Gibraltar" },
                    { 85, "3018", "GR", "Greece", "Grécia" },
                    { 86, "3050", "GL", "Greenland", "Groenlândia" },
                    { 87, "2976", "GD", "Grenada", "Granada" },
                    { 88, "3093", "GP", "Guadeloupe", "Guadalupe" },
                    { 89, "3131", "GU", "Guam", "Guam" },
                    { 90, "3174", "GT", "Guatemala", "Guatemala" },
                    { 91, "3298", "GN", "Guinea", "Guine" },
                    { 92, "3344", "GW", "Guinea-Bissau", "Guine-Bissau" },
                    { 93, "3379", "GY", "Guyana", "Guiana" },
                    { 94, "3417", "HT", "Haiti", "Haiti" },
                    { 81, "2917", "GE", "Georgia", "Georgia, Republica da" },
                    { 263, "7811", "TF", "Terres Australes et Antarctiques Françaises", "Terras Austrais e Antárcticas Francesas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileId",
                table: "User",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ProfileId",
                table: "Contact",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Profile_ProfileId",
                table: "User",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Profile_ProfileId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_User_ProfileId",
                table: "User");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "User");
        }
    }
}
