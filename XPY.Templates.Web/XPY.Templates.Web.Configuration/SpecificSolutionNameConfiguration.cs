using System;

namespace $safeprojectname$ {
    public partial class $lastnamespace$Configuration {
        public static $lastnamespace$Configuration Instance { get; private set; } = new $lastnamespace$Configuration();

public JWTConfiguration JWT { get; set; } = new JWTConfiguration();
public ConnectionStrings ConnectionStrings { get; set; } = new ConnectionStrings();
public SwaggerConfiguration Swagger { get; set; } = new SwaggerConfiguration();

private $lastnamespace$Configuration() { }
}

public class JWTConfiguration {
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecureKey { get; set; }
    public int Expires { get; set; }
}

public class ConnectionStrings {
    public string Default { get; set; }
}

public class SwaggerConfiguration {
    public string Name { get; set; }
    public string Description { get; set; }
}
}
