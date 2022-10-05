# validateEmails

it's a c# class library (.net framework) that validate email adresses.
it does three things:
1. it validates the email syntax
2. it validates the domain (checks whether the domain has an ip)
3. it validates whether the domain has a mail server connected with it.

dependencies:
ARSOFT.Tools.Net


now listen to my tragic story, a real and deal heartbreaker. i bought an email validator for 100$ and wanted to integrate it with azure.
the problem was that the component worked only with port 25, and azure blocks port 25 out of all ports (why lord why ?) and refuses to set it free. 
so i was stuck, and hence the solution. it's very simple one, the tools that are availabe make things really easy to write such a solution, but still. 
maybe one desparate soul will be salvaged by this piece of code (although i'm in serious doubt about it). 
and if that's the case than i'm more than happy, i'm blissed.
that's all folks.
