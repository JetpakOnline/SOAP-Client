using System;
using System.Linq;
using System.Windows.Forms;
using JetpakSoapClientExample.com.jetpak.testjena;
using System.Web.Services.Protocols;
using JetpakSoapClientExample.Properties;
using System.Drawing;

namespace JetpakSoapClientExample
{
    public partial class JetpakSoapClientForm : Form
    {
        public JetpakSoapClientForm()
        {
            InitializeComponent();

            var externalBooking = CreateExternalCourierBooking();

            SetTransportGuiData(externalBooking);
        }

        private void searchTrpAltBtn_Click(object sender, EventArgs e)
        {
            var bookingClient = new JenaExternalBookingWebService
            {
                SoapVersion = SoapProtocolVersion.Soap11
            };

            /* Fill out booking data */
            var externalBooking = UserPickedBookingTypeInForm == Resources.JPSClientForm_JPSClientForm__Flight 
                ? CreateExternalFlightBooking() 
                : CreateExternalCourierBooking();

            SetTransportGuiData(externalBooking);
            
            /* Get transport alternatives */
            var transportAlternatives = bookingClient.JenaGetTransportAlternatives(externalBooking);

            SetTransportAlternativeRadioButtons(transportAlternatives, UserPickedBookingTypeInForm);

        }

        private void makeBookingBtn_Click(object sender, EventArgs e)
        {           
            var bookingClient = new JenaExternalBookingWebService
            {
                SoapVersion = SoapProtocolVersion.Soap11
            };

            /* Fill out booking data, flight or courier */
            var externalBooking = UserPickedBookingTypeInForm == Resources.JPSClientForm_JPSClientForm__Flight 
                ? CreateExternalFlightBooking() 
                : CreateExternalCourierBooking();

            /* Set transport alternative with chosen TransportAlternativeId (received from JenaGetTransportAlternatives response) */
            externalBooking.Body.Shipments[0].TransportAlternativeId = UserPickedTransportAlternativeInForm;

            /* Make the booking, response will be returned */
            var bookingConfirmation = bookingClient.JenaExternalBooking(externalBooking);

            /* Check booking status in response, "Item2" = booking is definitive (everything ok) */
            if (bookingConfirmation.Body.Shipments[0].Status == ShipmentStatusType.Item2)
            {              
                resultTextBox.Text = Resources.JPSClientForm_JPSClientForm_Booking_confirmed_;

                /* Jetpak booking reference */
                resultTextBox.Text += Environment.NewLine + Resources.JPSClientForm_JPSClientForm_Jetpak_booking_reference__ + bookingConfirmation.Body.Shipments[0].AwbNbr;
            }
            else
            {
                /* Display error texts */
                resultTextBox.Text += Resources.JPSClientForm_JPSClientForm__booking_not_confirmed__ + bookingConfirmation.Body.Shipments[0].ErrorTexts[0];
            }
        }

        private static ExternalBooking CreateExternalCourierBooking()
        {
            var externalBooking = new ExternalBooking
            {
                Header = new HeaderType
                {
                    /* Booking time stamp */
                    Date = DateTime.Today,
                    Time = DateTime.Now,

                    /* Your user credentials, given by Jetpak */
                    UserName = "user",
                    Password = "password",
                },
                Body = new BodyType
                {
                    /* Your customer number, given by Jetpak */
                    CustomerNbr = "999999",

                    /* Your customer product, given by Jetpak */
                    CustomerProduct = "product",

                    Shipments = new[]
                                {
                                    new ShipmentsTypeShipment
                                        {
                                            /* Your shipment reference */
                                            ShipmentId = "1234567890",

                                            /* What are you shipping? (Content) */
                                            NatureOfGoods = "Documents",

                                            FromCountry = "SE",
                                            ToCountry = "SE",
                                            FromCity = "Stockholm",
                                            ToCity = "Stockholm",

                                            /* Shipment picked up by Jetpak (always YES for courier) */
                                            Pickup = YesNoType.Y,

                                            /* Shipment delivered by Jetpak (always YES for courier) */
                                            Delivery = YesNoType.Y,

                                            /* Earliest pickup */
                                            ReadyDateTime = DateTime.Today.AddDays(1).ToShortDateString() + " 10:00",

                                            LatestDeliveryDateTime = DateTime.Today.AddDays(1).ToShortDateString() + " 18:00",

                                            Shipper = new ContactType
                                                {
                                                    Name = "Shipper Company AB",
                                                    Street = "Ringvägen",
                                                    StreetNbr = "100",
                                                    PostCode = "11860",
                                                    EntryCode = "1234",
                                                    ContactPerson = new ContactPersonType
                                                        {
                                                            FirstName = "Anders",
                                                            SurName = "Testavsändare",
                                                            PhoneNbr = "08-123456",
                                                            Email = "test@test.com",
                                                        }
                                                },

                                            Consignee = new ContactType
                                                {
                                                    Name = "Consignee Company AB",
                                                    Street = "Sveavägen",
                                                    StreetNbr = "35",
                                                    PostCode = "11134",
                                                    EntryCode = "4321",
                                                    ContactPerson = new ContactPersonType
                                                        {
                                                            FirstName = "Test",
                                                            SurName = "Consignee",
                                                            PhoneNbr = "08-654321",
                                                            Email = "test@test.com",
                                                        }
                                                },
                                            Payer = new PayerType
                                                {
                                                    /* Item2 = Invoice payment (mandatory option) */
                                                    PaymentMethod = PaymentMethodType.Item2,

                                                    /* Your own payment reference on invoice */
                                                    Reference = "12345",
                                                },
                                            Advises = new[]
                                                {
                                                    new AdvisesTypeAdvise
                                                        {
                                                            /* Send an email advise when shipment on different actions;
                                                             * Item0 = advise activated, Item1 = inactivated */

                                                            /* Booking confirmation */
                                                            SendDef = BooleanType.Item0,

                                                            /* Status update */
                                                            SendStatus = BooleanType.Item0,

                                                            /* Confirmation that shipment has been delivered */
                                                            SendPod = BooleanType.Item0,

                                                            /* Shipment har been rebooked by Jetpak */
                                                            SendRebook = BooleanType.Item0,
                                                            
                                                            Method = MethodType.EMAIL,
                                                            Address = "test@test.com",
                                                        }
                                                },
                                            Packages = new[]
                                                {
                                                    new PackagesTypePackage
                                                        {
                                                            /* Content of the package */
                                                            NatureOfGoods = "Document",

                                                            /* Package dimension [cm] */
                                                            Weight = 5,
                                                            Length = 25,
                                                            Width = 10,
                                                            Height = 40,
                                                        }
                                                },
                                        }
                                }
                },
            };
            return externalBooking;
        }

        private static ExternalBooking CreateExternalFlightBooking()
        {
            var externalBooking = new ExternalBooking
            {
                Header = new HeaderType
                {
                    /* Booking time stamp */
                    Date = DateTime.Today,
                    Time = DateTime.Now,

                    /* Your user credentials, given by Jetpak */
                    UserName = "user",
                    Password = "password",
                },
                Body = new BodyType
                {
                    /* Your customer number, given by Jetpak */
                    CustomerNbr = "999999",

                    /* Your customer product, given by Jetpak */
                    CustomerProduct = "product",

                    Shipments = new[]
                                {
                                    new ShipmentsTypeShipment
                                        {
                                            /* Your shipment reference */
                                            ShipmentId = "1234567890",

                                            /* What are you shipping? (Content) */
                                            NatureOfGoods = "Documents",

                                            FromCountry = "SE",
                                            ToCountry = "SE",
                                            FromCity = "Stockholm",
                                            ToCity = "Göteborg",

                                            /* YES = Shipment picked up by Jetpak, NO = Handed over at airport*/
                                            Pickup = YesNoType.Y,

                                            /* YES = Shipment delivered by Jetpak, NO = You pick up at airport*/
                                            Delivery = YesNoType.Y,

                                            /* Tidigaste upphämtning */
                                            ReadyDateTime = DateTime.Today.AddDays(0).ToShortDateString() + " 10:00",

                                            LatestDeliveryDateTime = DateTime.Today.AddDays(1).ToShortDateString() + " 18:00",

                                            /* Avsändare */
                                            Shipper = new ContactType
                                                {
                                                    Name = "Shipper Company AB",
                                                    Street = "Ringvägen",
                                                    StreetNbr = "100",
                                                    PostCode = "11860",
                                                    EntryCode = "1234",
                                                    ContactPerson = new ContactPersonType
                                                        {
                                                            FirstName = "Test",
                                                            SurName = "Shipper",
                                                            PhoneNbr = "08-123456",
                                                            Email = "test@test.com",
                                                        }
                                                },

                                            /* Mottagare */
                                            Consignee = new ContactType
                                                {
                                                    Name = "Consignee Company AB",
                                                    Street = "Storgatan",
                                                    StreetNbr = "1",
                                                    PostCode = "41124",
                                                    EntryCode = "4321",
                                                    ContactPerson = new ContactPersonType
                                                        {
                                                            FirstName = "Test",
                                                            SurName = "Consignee",
                                                            PhoneNbr = "031-654321",
                                                            Email = "test@test.com",
                                                        }
                                                },
                                            Payer = new PayerType
                                                {
                                                    /* Item2 = Betalningsmetod faktura */
                                                    PaymentMethod = PaymentMethodType.Item2,

                                                    /* Your own payment reference on invoice */
                                                    Reference = "12345",
                                                },
                                            Advises = new[]
                                                {
                                                    new AdvisesTypeAdvise
                                                        {
                                                            /* Send an email advise when shipment on different actions;
                                                             * Item0 = advise activated, Item1 = inactivated */

                                                            /* Booking confirmation */
                                                            SendDef = BooleanType.Item0,

                                                            /* Status update */
                                                            SendStatus = BooleanType.Item0,

                                                            /* Confirmation that shipment has been delivered */
                                                            SendPod = BooleanType.Item0,

                                                            /* Shipment har been rebooked by Jetpak */
                                                            SendRebook = BooleanType.Item0,
                                                            
                                                            Method = MethodType.EMAIL,
                                                            Address = "test@test.com",
                                                        }
                                                },
                                            Packages = new[]
                                                {
                                                    new PackagesTypePackage
                                                        {
                                                            /* Content of the package */
                                                            NatureOfGoods = "Document",

                                                            /* Package dimension [cm] */
                                                            Weight = 5,
                                                            Length = 25,
                                                            Width = 10,
                                                            Height = 40,
                                                        }
                                                },
                                        }
                                }
                },
            };
            return externalBooking;
        }

        private void SetTransportGuiData(ExternalBooking externalBooking)
        {
            fromAddressTextBox.Text = string.Format("{0} {1}{2} {3}{4}{5} {6}", externalBooking.Body.Shipments[0].Shipper.Name, Environment.NewLine,
                                        externalBooking.Body.Shipments[0].Shipper.Street, externalBooking.Body.Shipments[0].Shipper.StreetNbr, Environment.NewLine,
                                        externalBooking.Body.Shipments[0].Shipper.PostCode, externalBooking.Body.Shipments[0].FromCity);

            pickupDateTextBox.Text = string.Format("{0} {1}",externalBooking.Body.Shipments[0].ReadyDateTime,
                                        externalBooking.Body.Shipments[0].EarliestDeliveryDateTime);


            toAddressTextBox.Text = string.Format("{0} {1}{2} {3}{4}{5} {6}", externalBooking.Body.Shipments[0].Consignee.Name, Environment.NewLine,
                                        externalBooking.Body.Shipments[0].Consignee.Street, externalBooking.Body.Shipments[0].Consignee.StreetNbr, Environment.NewLine,
                                        externalBooking.Body.Shipments[0].Consignee.PostCode, externalBooking.Body.Shipments[0].ToCity);

            deliveryDateTextBox.Text = externalBooking.Body.Shipments[0].LatestDeliveryDateTime;
        }

        private void ClearResultsInGui()
        {
            resultTextBox.Text = string.Empty;
            transportAlternativeGroupBox.Controls.Clear();
        }

        private void flightBookingTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var externalBooking = CreateExternalFlightBooking();

            SetTransportGuiData(externalBooking);

            makeBookingButton.Enabled = false;
        }

        private void courierBookingTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var externalBooking = CreateExternalCourierBooking();

            SetTransportGuiData(externalBooking);

            makeBookingButton.Enabled = false;
        }

        private string UserPickedBookingTypeInForm
        {
            get
            {
                var firstOrDefault = bookingDataGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
                return firstOrDefault != null ? firstOrDefault.Text : null;
            }
        }

        private string UserPickedTransportAlternativeInForm
        {
            get
            {
                var firstOrDefault = transportAlternativeGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
                return firstOrDefault != null ? firstOrDefault.Name : null;
            }
        }

        private void SetTransportAlternativeRadioButtons(TransportAlternatives transportAlternatives, string displayType)
        {
            ClearResultsInGui();

            if (transportAlternatives.Alternatives != null)
            {
                if (transportAlternatives.Alternatives.Length > 0)
                {
                    if (displayType == Resources.JPSClientForm_JPSClientForm__Courier)
                    {
                        for (var i = 0; i < transportAlternatives.Alternatives.Length; i++)
                        {
                            var transportAlternativeRadioButton = new RadioButton
                            {
                                Width = 20,
                                Height = 20,
                                Location = new Point(20, (i * 20) + 20),
                                Name = transportAlternatives.Alternatives[i].Id
                            };
                            if (i == 0) transportAlternativeRadioButton.Checked = true;

                            var trpLbl = new Label
                            {
                                Height = 20,
                                Width = transportAlternativeGroupBox.Width - 60,
                                Text = transportAlternatives.Alternatives[i].Component +
                                       Resources.JetpakSoapClientForm_setTransportAlternativeRadioButtons__Delivery__ +
                                       transportAlternatives.Alternatives[i].LatestDeliveryDateTime,
                                Location = new Point(50, (i * 20) + 20)
                            };
                            transportAlternativeGroupBox.Controls.Add(transportAlternativeRadioButton);
                            transportAlternativeGroupBox.Controls.Add(trpLbl);
                            makeBookingButton.Enabled = true;
                        }
                    }
                    else
                    {
                        for (var i = 0; i < transportAlternatives.Alternatives.Length; i++)
                        {
                            var transportAlternativeRadioButton = new RadioButton
                            {
                                Width = 20,
                                Height = 20,
                                Location = new Point(20, (i * 20) + 20),
                                Name = transportAlternatives.Alternatives[i].Id
                            };
                            if (i == 0) transportAlternativeRadioButton.Checked = true;

                            var trpLbl = new Label
                            {
                                Height = 20,
                                Width = transportAlternativeGroupBox.Width - 60,
                                Text = transportAlternatives.Alternatives[i].DepartureTransferpoint + " - " +
                                       transportAlternatives.Alternatives[i].ArrivalTransferpoint +
                                       Resources.JetpakSoapClientForm_setTransportAlternativeRadioButtons__Latest_Delivery__ +
                                       transportAlternatives.Alternatives[i].LatestDeliveryDateTime,
                                Location = new Point(50, (i * 20) + 20)
                            };
                            transportAlternativeGroupBox.Controls.Add(transportAlternativeRadioButton);
                            transportAlternativeGroupBox.Controls.Add(trpLbl);
                            makeBookingButton.Enabled = true;
                        }
                    }
                }
                else
                {
                    resultTextBox.Text += Resources.JPSClientForm_JPSClientForm__No_transport_alternatives;
                    makeBookingButton.Enabled = false;
                }
            }
            else
            {
                resultTextBox.Text = Resources.JPSClientForm_JPSClientForm__Transport_alternatives_not_set__ + transportAlternatives.ErrorTexts[0];
                makeBookingButton.Enabled = false;
            }
        }
    }
}
