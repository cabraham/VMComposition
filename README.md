# VMComposition

## Description
This is a sandbox playground to build out a ViewModel composition framework.  The purpose is to have an easy-to-use solution to gather data distributed across many boundaries in one request call.

## Vision
In an SOA system, data will be split up across N boundaries.  When a request to pull data is made, often times, that data will be pulled from many sources to make a cohesive page for a specific use-case.

For example, when a user views a product on Amazon, the page will display product information such as product name, description, pricing, reviews, inventory, shipping options, etc.  These details would not be stored in one database but across many datasources according to the business domain and context.  How does the ViewModel for a page get populated when the details are separated in different sources?  

Most approaches would have the requestor "know" where the data is.  It may be that there is one level of indirection where the requestor calls to a service, and that service knows how to make these calls.  The same problem exists however and is simply moved one level further away.

The main problem is that the requestor has the knowledge to pull this data together.  When the ViewModel changes, the requestor changes.  Everytime a web-page has a new feature or modification, the requestor also has to have knowledge of this change and account for it.  

The goal of this project is to see if we can flip the dependency.  I want the requestor to say "I want X".  All the services listen to this statement, and respond to the request with the data for which they are responsible.

The conversation would be: 

**Requestor**: I want to see product details for product id ABC.

**VMC**: Marketing, are you interested in this request?  
**Marketing**: Yes, I have the name and description.  Here they are.

**VMC**: Inventory, are you interested in this request?  
**Inventory**: Yes, I can tell you if the product is still available and if not, when it will be.  Here's the info.

**VMC**: Shipping, are you interested in this request?  
**Shipping**: No, I don't care about this request.  Bye Felicia!

**VMC**: Sales, are you interested in this request?  
**Sales**: Yes, I have the pricing details.  Here you go!

**VMC**: Alright Requestor, here's your response!


## Technical Details

This solution requires an engine (ViewModel Composition Engine) that is aware of all the services.  Its primary role is to declaratively state "I want X" and match up the request with the services that are listening for this request.  

To make this happen, all services would register themselves with the VMCE.  This registration should be automatic and not actually require the service to be aware of the VMCE.  This would happen upon system-startup through a common interface that all services would apply.  An assembly scanner would scan for all instances of this interface and be made aware of the participating services.

Requests, although often Http, are not always Http.  The VMCE should be abstracted away from the VMCE as well.  The VMCE should only be aware of the ViewModel, its parameters, and the participating services.  


### Overall Flow

- Web Startup
  - AssemblyScan for all handlers
  - Register with container

- Web Request
  - ViewModel implements a number of marker interfaces
    - INeedProductPrice, INeedProductDescription, INeedProductAvailability, etc
    - VMC receives viewmodel
      - VMC pulls out all marker interfaces
      - VMC asks all handlers if they are interested in this interface
      - VMC executes handlers
      - VMC gathers all results and places in ViewModel
    - Return ViewModel