<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128590649/15.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4904)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->

# XAF XPO - How to Generate a Sequential User-friendly Identifier Field

This example illustrates one of the possible approaches to implement a user-friendly identifier field with sequential values in an XPO business class.

## Scenario

Orders, articles, or other business entities often require that you have user-friendly **Id** or **Code** fields that end-users can memorize and use during phone conversations. They are usually sequential, but some gaps can be allowed as well, for example, when an order is deleted. Refer to <a href="http://stackoverflow.com/questions/5924499/"><u>this StackOverFlow thread</u></a> for more information on this common scenario and a possible implementation.

## Steps to implement

1. Add a new business class to your platform-agnostic module.

2. In the `OnSaving` method, call the static `DevExpress.Persistent.BaseImpl.DistributedIdGeneratorHelper.Generate` method. 

   Depending on your business requirements, you can implement a readonly persistent or editable property where the generated value will be stored. You can also perform various checks before you generate the next sequence, such as:
   
   * `string.IsNullOrEmpty(currentSequenceProperty)`. Avoids double assignments.
   
   * `Session.IsNewObject(this)`. Checks whether the object is new.
   
   * `!(Session is NestedUnitOfWork)`. Checks whether the object is being saved to the database and not to the parent session.
   
   * Security system checks as per this blog post [about Session.DataLayer property](http://dennisgaravsky.blogspot.com/2013/03/beware-of-sessiondatalayer-in-middle.html). 

   > **Note**
   > You can use any strings as the `seqType` and `serverPrefix` (optional) parameters that allow you to run named sequences in parallel. These parameters determine criteria for updating right sequences. The demo uses the full persistent type name and a custom prefix that you can change: 
   >
   > ![Parameters Example](/media/parameter-strings.png)  
   
4. Build your platform-agnostic project and double-click on the _Solution2.Module\Module.xx_ file to invoke the [Module Designer](http://documentation.devexpress.com/#Xaf/CustomDocument2828). 

5. Refer to the **Exported Types** section within the designer and expand the **Referenced Assemblies | DevExpress.Persistent.BaseImpl** node. 

6. Select the **OidGenerator** node and press the space bar to include this persistent type into the business model of your module: 
   
   ![OidGenerator node in Module Designer](media/module-designer-oidgenerator-node.png)

## Additional information
  
1. The `DistributedIdGeneratorHelper` class demonstrated in this solution creates the **IDGeneratorTable** table to store the information about the last sequential number of a type. You can learn more on how this works from its source code at _C:\Program Files (x86)\DevExpress 1X.X\Components\Sources\DevExpress.Persistent\DevExpress.Persistent.BaseImpl\IDGenerator.cs_. 

   This particular solution uses built-in XAF classes and is simpler to implement and maintain than the [How to generate and assign a sequential number for a business object within a database transaction, while being a part of a successful saving process (XAF)](https://www.devexpress.com/Support/Center/p/E2829) example. Nevertheless, it is pretty safe and should also work in the most typical business scenarios.

2. If you have validation rules for your business class, the `OnSaving` method (and thus the sequence generation) is called only after all validation is passed. However, in rare cases, if a database related error is thrown during the first save and then the form is re-saved, the`OnSaving` method may be called again and a new sequence can be generated. This may lead to gaps in sequential numbers, which is not always allowed by business requirements (e.g., government regulations). To avoid this, you can use a more complicated solution from the [How to generate and assign a sequential number for a business object within a database transaction, while being a part of a successful saving process (XAF)](https://www.devexpress.com/Support/Center/p/E2829) example or implement a database-level solution to handle such situations, for example, using triggers. 

3. In the [Integrated Mode](https://docs.devexpress.com/eXpressAppFramework/113436/data-security-and-safety/security-system/security-tiers/2-tier-security-integrated-mode-and-ui-level) and [Middle Tier Application Server](https://docs.devexpress.com/eXpressAppFramework/113439/data-security-and-safety/security-system/security-tiers/middle-tier-security) scenarios, the newly generated sequence number will appear in the DetailView only after a manual refresh, because the sequence is generated on the server side only and is not passed to the client. For additional information, refer to the [Refresh the Identifier field value in UI" section](https://www.devexpress.com/Support/Center/p/T567184) KB article.

4. You can find functional [EasyTest](https://docs.devexpress.com/eXpressAppFramework/113211/debugging-testing-and-error-handling/functional-tests-easy-test) scripts for this scenario in the _Solution2.Module\FunctionalTests\E4904.ets_ file. 

5. You can specify the initial sequence value manually. Use either of the following ways: 
   
   * Edit the **IDGeneratorTable** table in the database.
   * Manipulate the `DevExpress.Persistent.BaseImpl.OidGenerator` objects. For additional information, refer to the [Create, Read, Update and Delete Data](https://docs.devexpress.com/eXpressAppFramework/113711/data-manipulation-and-business-logic/create-read-update-and-delete-data) article about data manipulation in XPO/EF Core-based solutions.
   * Use a different server prefix to start numbering with 1 again. For example, "2017" or "2018".

## Files to Review

* [TestUserFriendlyCodeObject.cs](./CS/Solution2.Module/BusinessObjects/TestUserFriendlyCodeObject.cs) (VB: [TestUserFriendlyCodeObject.vb](./VB/Solution2.Module/BusinessObjects/TestUserFriendlyCodeObject.vb))
* [E4904.ets](./CS/Solution2.Module/FunctionalTests/E4904.ets) (VB: [E4904.ets](./VB/Solution2.Module/FunctionalTests/E4904.ets))

## Documentation

* [An overview of approaches to implementing a user-friendly sequential number for use with an XPO business class](https://www.devexpress.com/Support/Center/p/T567184)
