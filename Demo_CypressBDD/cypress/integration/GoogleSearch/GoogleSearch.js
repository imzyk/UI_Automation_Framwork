let info = "";

Given('I navigate to Google site', () => {
  cy.visit("http://www.google.com")
});

When('I search with keyword {string}', (keyword) => {
  info = keyword
  cy.get("input[name=q]").type(keyword + "\n")
});

Then('I should see related citing', () => {
  cy.get("div > cite").first().should("contain", info)
});