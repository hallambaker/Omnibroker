Omnibroker
==========

Implements the Omnibroker specification proposed in IETF.

The code bundle contains source for a client, a server and the source code to generate the Internet Draft and the 
examples within it.

The basic idea of Omnibroker is to provide access to all the trust services required by a client through a common
protocol. This in turn enables those services to be supported through a single entity that can curate the trust
data provided. It is conceptually an anti-virus for Internet communications. 

For example, a Web browser today relies on the DNS for naming services, OCSP for certificate services. It is
also likely that the user will choose to add access to a bookmark service, a password saving service and so on.
Each one of these connections has consequences for trust.

The trust data is still originated in the traditional fashion, using DNS, OCSP etc. What changes is the way that
the data is consumed. Instead of the data being consumed directly by the client, it is first currated by the
service. 

In the traditional model the client trusts the data because it comes from an authoritative source, a model that
made sense in the Internet of 1980 when the network administrators were mostly trustworthy. That model has broken
down as malicious parties have gained control of many ISPs, DNS Registrars and on occasion even a CA.

In the omnibroker model, the client chooses an omnibroker whose responsibility it is to decide which
authoritative sources are to be trusted. The mere fact that the Russian Business Network has registered a 
DNS domain name does not mean that anyone sensible wants to vist their site with a browser. 

Who you trust as an omnibroker and the extent to which you trust them depends on your circumstances. The typical 
consumer has no problem letting Comodo, Symantec, McAfee, Kaspersky et. al. decide what programs run on their
machines. Reliance on an omnibroker supported by the same vendor does not represent an additional risk.

In an enterprise, the omnibroker is equivalent to a DNS resolver. Most enterprises that run a local DNS resolver
would probably choose to run a local Omnibroker service in the same fashion. such an omnibroker service would
probably make use of network intelligence data provided by a security provider as at least one of its data 
inputs.


Notes
=====

Version 0.1: Just generates the examples for the Internet Draft.

To Do
=====

* Implement as a stanadlone service
* Forward requests to DNS recursive resolver
* Implement as an ISAPI plugin
* Implement as an Apache pplugin