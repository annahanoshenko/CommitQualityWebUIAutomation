# CommitQualityWebUIAutomation
My user interface testing web application project, https://commitquality.com/, consists of two parts.

In the first part, I added automated logic to each page, created order and user entities, and together with the added methods, I used them to reduce code duplication. In PageBase, I added GetAlertWithWait and AcceptAlert methods for correct work with alerts, and added ContainsClass and SwitchToIFrame methods for correct work with classes and frames.  In tests, I conduct positive and negative testing for login, logout, adding, editing, and working with the product through the product's page and the menu bar.

-I create a wrapper over an IWebElement. I created a specific class that represents a table of rows in a website with specific properties. I created an input collection, IWebElements IWebElement[] TableProductRows, and based on it, I created an output collection,public ProductRow[] ProductRows, using Linq methods.
-I created a Helpers folder, where I created a class for generating new product names. using the Random class.
-I used JavaScriptExecutor to manipulate the DateStocked field, using the clearing method.

In the second part, learned to create Ui tests using Selenium Webdriver and NUnit with General Components: click me button, double click, right click, radio buttons, dropdowns, checkboxes, accordions, popups. Also, I practiced writing tests with iframes, dynamic text, file upload, drag and drop, contact us form, and file download.

What's new: created an extensions folder for web elements.
In this part, I practiced implementing the Singleton pattern for our driver and moved this logic there. Also, I simplified the code for reuse: add extension method ClearWithBackSpaceByValueAttribute in WebElementsExtensions class and move common logic there.

