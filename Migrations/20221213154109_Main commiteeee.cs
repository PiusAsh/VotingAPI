using Microsoft.EntityFrameworkCore.Migrations;

namespace VotingAPI.Migrations
{
    public partial class Maincommiteeee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Votes_TotalVotesId",
                table: "Candidates");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_TotalVotesId",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "TotalVotesId",
                table: "Candidates");

            migrationBuilder.AddColumn<int>(
                name: "TotalVotes",
                table: "Candidates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalVotes",
                table: "Candidates");

            migrationBuilder.AddColumn<int>(
                name: "TotalVotesId",
                table: "Candidates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_TotalVotesId",
                table: "Candidates",
                column: "TotalVotesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Votes_TotalVotesId",
                table: "Candidates",
                column: "TotalVotesId",
                principalTable: "Votes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
