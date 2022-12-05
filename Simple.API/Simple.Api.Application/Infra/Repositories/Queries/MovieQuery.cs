namespace Simple.Api.Application.Infra.Repositories.Queries
{
    public static class MovieQuery
    {
        public static string GetListMovies => @"SELECT
                                                 MovieId ,
                                                 MovieTitle ,
                                                 MovieAvailable 
                                                 FROM
                                                 dbo.Movie (NOLOCK)
                                                 ORDER BY MovieTitle DESC
                                                 OFFSET(@page - 1) * @quantity ROWS
                                                 FETCH NEXT @quantity ROWS ONLY; ";

        public static string GetMovie => @"SELECT MovieId ,
                                                 MovieTitle ,
                                                 MovieAvailable 
                                                 FROM
                                                 dbo.Movie (NOLOCK)
                                                 WHERE MovieId = @MovieId ";


        public static string InsertMovie => @" INSERT INTO [dbo].[Movie]
                           ([MovieId]
                           ,[MovieTitle]
                           ,[MovieAvailable]) 
                OUTPUT INSERTED.MovieId
                     VALUES
                           (@MovieId, @MovieTitle, @MovieAvailable) ";

        public static string UpdateMovie => @"   
                        UPDATE [dbo].[Movie] SET  
                        MovieTitle = @MovieTitle, 
                        MovieAvailable = @MovieAvailable
                        WHERE MovieId = @MovieId ";

    }
}
