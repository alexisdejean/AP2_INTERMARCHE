CREATE PROCEDURE ajouter_commande
    @idCommande INT,
    @nomProduit NVARCHAR(255),
    @quantite INT
AS
BEGIN
    DECLARE @codeProduit INT

    IF NOT EXISTS (SELECT * FROM Commande WHERE idCommande = @idCommande)
    BEGIN
        RAISERROR('Commande inexistante', 16, 1)
        RETURN
    END

    SELECT @codeProduit = codeProduit 
    FROM Produit 
    WHERE libelleProduit LIKE '%' + @nomProduit + '%'
	begin tran
    IF @codeProduit IS NULL
    BEGIN
        INSERT INTO Produit (libelleProduit) VALUES (@nomProduit)
        SELECT @codeProduit = codeProduit 
        FROM Produit 
        WHERE libelleProduit = @nomProduit
		if(@@ERROR != null) or (@@ROWCOUNT = 0)
		begin
			rollback tran
			raiserror('erreur ajout produit',16,1)
			return
		end
    END
    
    IF EXISTS (SELECT * FROM Commander WHERE idCommande = @idCommande AND codeProduit = @codeProduit)
    BEGIN
        UPDATE Commander 
        SET quantite = quantite + @quantite
        WHERE idCommande = @idCommande AND codeProduit = @codeProduit
		if(@@ERROR != null) or (@@ROWCOUNT = 0)
		begin
			rollback tran
			raiserror('erreur modification commande',16,1)
			return
		end
    END
    ELSE
    BEGIN
        INSERT INTO Commander (idCommande, codeProduit, quantite)
        VALUES (@idCommande, @codeProduit, @quantite)
		if(@@ERROR != null) or (@@ROWCOUNT = 0)
		begin
			rollback tran
			raiserror('erreur ajout commande',16,1)
			return
		end
		commit tran
    END
END
GO