# WordPress.Providers

*This project is still private prototype*

Library provides access to autorization using WordPress database through common .NET Provider's: MembershipProvider, RoleProvider, ???

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
