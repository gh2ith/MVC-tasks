# Graduation Supply Management

ASP.NET Core MVC learning task. Requires .NET 10. No database is used.

## Run

Open GraduationSupplyManagement.slnx in Visual Studio and run the project.
The application starts on the Create Supply Request page.

## Phase 2 (default)

TaskPhase is set to 2 in appsettings.json. Selected offers are stored as a
List<Offer>, serialized to JSON in one Session key named SelectedOffers.
Selecting another offer in a category replaces that category's previous offer.
Review is blocked until exactly one offer from each of the three categories
has been selected. All offer totals, discounts and final totals are calculated
in SupplyController.Review and passed to the view through ViewBag.

## Phase 1 comparison

Set TaskPhase to 1 and restart the application to demonstrate separate Session
keys: CertificatesOffer, HospitalityOffer and GiftsOffer. These are separate
from the Phase 2 list. Use a new private browser window for a fresh session.

## Task rules

There are nine offers, three per category. The employee makes all selections.
Totals above 500 JD receive 15% off; above 300 JD up to 500 JD receive 10% off;
300 JD or less receives no discount. The LastSupplier cookie remembers the
last supplier name and does not restore or choose offers automatically.

## Main files

- Controllers/SupplyController.cs: actions, Session storage and calculations.
- Data/OfferCatalog.cs: the nine offers from the task.
- Models/Offer.cs: the offer properties.
- Views/Supply/Create.cshtml: categories and selection buttons.
- Views/Supply/Review.cshtml: the selected offers and calculated costs.
- Views/Supply/About.cshtml: the required application description.
- Views/Shared/_Layout.cshtml: navigation links using Url.Action.
- Program.cs: Session registration and the default route.

Phase 3 is not implemented in this version.
