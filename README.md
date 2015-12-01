# WordPress.Providers

*This project is still private prototype*

Provides access to Wordpress database through .NET Provider's system: MembershipProvider, RoleProvider and others

## MySql Way

### Sample web.config

```xml
	<!-- ... -->
    <membership defaultProvider="WordpressMembershipProvider">
      <providers>
        <add
		  connectionStringName="NAME"
		  name="WordpressMembershipProvider"
		  type="WordPress.Providers.MySql.WordpressMembershipProvider, WordPress.Providers" />
      
	  </providers>
    </membership>

    <roleManager defaultProvider="WordpressRoleProvider" enabled="true">
      <providers>
        <add
		  connectionStringName="NAME"
		  name="WordpressRoleProvider"
		  type="WordPress.Providers.MySql.WordpressRoleProvider, WordPress.Providers" />
      
	  </providers>
    </roleManager>
	<!-- ... -->
```

## CREDITS

* **CryptSharp** : http://www.zer7.com/software/cryptsharp
