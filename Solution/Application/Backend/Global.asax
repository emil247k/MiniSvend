<%@ Application Language="C#" %>  
<script runat="server">  
    void Session_Start(object sender, EventArgs e)  
    {  
        var sessionID = Session.SessionID
    }  
    void Session_End(object sender, EventArgs e)  
    {  
        var databaseContext = DependencyResolver.Current.GetService<DatabaseContext>();  
        sessionContext = DependencyResolver.Current.GetService<SessionContext>();
        string token = sessionContext.getToken("token");
        SmartLock.Models.User.User user = await databaseContext.Set<SmartLock.Models.User.User>()
            .FirstOrDefaultAsync(x => x.ActivToken == token);
        if(user != default)
        {
            user.ActivToken = "";
            databaseContext.SaveChanges();
            sessionContext.RemoveToken("token");
            return true;
        }
    }  
</script>