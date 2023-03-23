namespace Product.Application.Infra.Repositories.Base
{
    internal static class ProductQuery
    {
        public static string GetList(string where) => $@"  SELECT  p.* FROM PRODUCT(NOLOCK) p 
                                                            {where}
                                                            group by p.ProductId, p.ProductName, p.ProductDescription, p.Price, p.CreatedDate, p.UpdatedDate
                                                            order by p.ProductName
                                                            OFFSET(@page - 1) * @quantity ROWS
                                                            FETCH NEXT @quantity ROWS ONLY; ";

        public static string Get => $@"   SELECT p.* FROM PRODUCT(NOLOCK) p  WHERE p.ProductId = @ProductId ";



        public static string Insert => @"   
           INSERT INTO [dbo].[PRODUCT]
           ([ProductName],
			[ProductDescription],
            [CreatedDate],
            [UpdatedDate],
            [Price]
            )
           OUTPUT INSERTED.ProductId
           VALUES
           (@ProductName,
			@ProductDescription,
            @CreatedDate ,
            @UpdatedDate ,
            @Price )
        ";



        public static string Update => @"  
           UPDATE[dbo].[PRODUCT]
            SET 
            [ProductName] = @ProductName,
            [UpdatedDate] = @UpdatedDate,
            [Price] = @Price 
            WHERE ProductId = @ProductId
        ";

        public static string Delete => @" DELETE FROM PRODUCT WHERE ProductId = @ProductId ";

        public static string GetListImages => $@"   SELECT p.* FROM PRODUCT_IMAGE(NOLOCK) p  WHERE p.ProductId = @ProductId ";

        public static string InsertImages => @"  
           INSERT INTO [dbo].[PRODUCT_IMAGE]
           ([ProductId],
            [ImageUrl])
           OUTPUT INSERTED.ProductId
           VALUES
           (@ProductId,
            @ImageUrl)
        ";

        public static string DeleteImages => @" DELETE FROM PRODUCT_IMAGE WHERE ProductId = @ProductId ";
    }
}
