namespace Hal_Taalam.ViewModel.Admin
{
    public class AdminDashboardVM
    {
        public int CategoriesCount { get; set; }
        public int GamesCount { get; set; }
        public int PlayersCount { get; set; }
        public int QuestionsCount { get; set; }
        public bool IsDatabaseOnline { get; set; }
        public List<Models.Player> ?RecentPlayers { get; set; }
    }
}
