using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidadeFederacao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(70)", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroTelefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(70)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(70)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    CnpjId = table.Column<int>(type: "int", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Rg = table.Column<string>(type: "varchar(12)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TelefoneId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedors_Empresas_CnpjId",
                        column: x => x.CnpjId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fornecedors_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fornecedors_Telefones_TelefoneId",
                        column: x => x.TelefoneId,
                        principalTable: "Telefones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "Id", "Cnpj", "Nome", "UnidadeFederacao" },
                values: new object[,]
                {
                    { 1, "12345678910112", "Cervejaria Top", "Santa Catarina" },
                    { 9, "26987453122447", "Livraria Mundo Bacana", "São Paulo" },
                    { 8, "11177799911224", "Batatão Alemão", "São Paulo" },
                    { 7, "22244498788994", "Academia Do Conhecimento", "Rio de Janeiro" },
                    { 6, "55577741233112", "Alegria Musical", "Rio de Janeiro" },
                    { 10, "56421378954132", "Chapéu Colorido", "Bahia" },
                    { 4, "78451236955441", "Luminárias Do Sucesso", "Santa Catarina" },
                    { 3, "45678912341525", "Mercado Compre Mais", "Santa Catarina" },
                    { 2, "98765432121313", "Sorveteria Japonesa", "Santa Catarina" },
                    { 5, "26987453122447", "Norte Calçados", "Santa Catarina" }
                });

            migrationBuilder.InsertData(
                table: "Telefones",
                columns: new[] { "Id", "Nome", "NumeroTelefone" },
                values: new object[,]
                {
                    { 11, "Daisy", "(21)9 0220-2059" },
                    { 18, "Gustavo", "(11)9 9990-0005" },
                    { 17, "Ademar", "(11)9 7997-0102" },
                    { 16, "Manuelle", "(11)9 5570-5551" },
                    { 15, "Rhuan", "(11)9 2224-4445" },
                    { 14, "Felipe", "(21)9 3331-1119" },
                    { 13, "Pedro", "(21)9 1598-7542" },
                    { 12, "Camila", "(21)9 9319-3344" },
                    { 10, "Roberto", "(47)9 7686-9612" },
                    { 5, "Arthur", "(47)9 3031-3235" },
                    { 8, "Robson", "(47)9 2010-4060" },
                    { 7, "David", "(47)9 7080-9050" },
                    { 6, "Gabrielle", "(47)9 5453-5759" },
                    { 19, "Marcia", "(71)9 9103-1250" },
                    { 4, "Maria", "(47)9 2021-2324" },
                    { 3, "Jaqueline", "(47)9 9091-9294" },
                    { 2, "Lucian", "(47)9 1234-4321" },
                    { 1, "Thiago", "(47)9 9214-7879" },
                    { 9, "Diego", "(47)9 7585-9555" },
                    { 20, "Invonesio", "(71)9 1444-2470" }
                });

            migrationBuilder.InsertData(
                table: "Fornecedors",
                columns: new[] { "Id", "CnpjId", "Cpf", "DataCadastro", "DataNascimento", "Email", "EmpresaId", "Idade", "Nome", "Rg", "TelefoneId" },
                values: new object[,]
                {
                    { 1, 1, "12345678922", new DateTime(2011, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1989, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "thiago@thiago.com", 1, 32, "Thiago", "9871234563", 1 },
                    { 18, 9, "51009548903", new DateTime(2007, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "gustavo@gustavo.com", 9, 30, "Gustavo", "2232242252", 18 },
                    { 17, 9, "32078094041", new DateTime(2009, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ademar@ademar.com", 9, 23, "Ademar", "1221231251", 17 },
                    { 16, 8, "01475098088", new DateTime(2013, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "manuelle@manuelle.com", 8, 25, "Manuelle", "2699874563", 16 },
                    { 15, 8, "02305809901", new DateTime(2013, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "rhuan@rhuan.com", 8, 29, "Rhuan", "2295584491", 15 },
                    { 14, 7, "85274196369", new DateTime(2017, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "felipe@felipe.com", 7, 28, "Felipe", "5438732102", 14 },
                    { 13, 7, "74125896359", new DateTime(2017, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2002, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "pedro@pedro.com", 7, 19, "Pedro", "3577535915", 13 },
                    { 12, 6, "23556889717", new DateTime(2016, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "camila@camila.com", 6, 27, "Camila", "5465644566", 12 },
                    { 11, 6, "97594814724", new DateTime(2016, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1998, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "daisy@daisy.com", 6, 23, "Daisy", "9632587419", 11 },
                    { 10, 5, "65342178941", new DateTime(2009, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "roberto@roberto.com", 5, 27, "Roberto", "5595585573", 10 },
                    { 9, 5, "95874543223", new DateTime(2009, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "diego@diego.com", 5, 35, "Diego", "4870009870", 9 },
                    { 8, 4, "21354687972", new DateTime(2005, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1984, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "robson@robson.com", 4, 37, "Robson", "5302548951", 8 },
                    { 7, 4, "31264597843", new DateTime(2005, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1982, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "david@david.com", 4, 39, "David", "9806503024", 7 },
                    { 6, 3, "79846513279", new DateTime(2019, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "gabrielle@gabrielle.com", 3, 20, "Gabrielle", "1590590870", 6 },
                    { 5, 3, "87645921387", new DateTime(2019, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2002, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "arthur@arthur.com", 3, 19, "Arthur", "7899871599", 5 },
                    { 4, 2, "32145698733", new DateTime(2015, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria@maria.com", 2, 25, "Maria", "0144100255", 4 },
                    { 3, 2, "45678912344", new DateTime(2015, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1999, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "jaqueline@jaqueline.com", 2, 22, "Jaqueline", "1748511236", 3 },
                    { 2, 1, "98765432111", new DateTime(2011, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucian@lucian.com", 1, 28, "Lucian", "1234567899", 2 },
                    { 19, 10, "55077011037", new DateTime(2006, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "marcia@marcia.com", 10, 31, "Marcia", "7787797747", 19 },
                    { 20, 10, "98078045012", new DateTime(2003, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1976, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "invonesio@invonesio.com", 10, 45, "Invonesio", "0980331115", 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedors_CnpjId",
                table: "Fornecedors",
                column: "CnpjId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedors_EmpresaId",
                table: "Fornecedors",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedors_TelefoneId",
                table: "Fornecedors",
                column: "TelefoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fornecedors");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Telefones");
        }
    }
}
