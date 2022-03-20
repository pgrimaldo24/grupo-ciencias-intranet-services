using System;
using System.Collections.Generic;

namespace GrupoCiencias.Intranet.CrossCutting.Dto.MercadoPago
{
    public class PaymentReceivedDto
    {
        public long id { get; set; }
        public DateTime? date_created { get; set; }
        public DateTime? date_approved { get; set; }
        public DateTime? date_last_updated { get; set; }
        public object date_of_expiration { get; set; }
        public DateTime? money_release_date { get; set; }
        public string operation_type { get; set; }
        public string issuer_id { get; set; }
        public string payment_method_id { get; set; }
        public string payment_type_id { get; set; }
        public string status { get; set; }
        public string status_detail { get; set; }
        public string currency_id { get; set; }
        public object description { get; set; }
        public bool? live_mode { get; set; }
        public object sponsor_id { get; set; }
        public string authorization_code { get; set; }
        public object money_release_schema { get; set; }
        public int? taxes_amount { get; set; }
        public object counter_currency { get; set; }
        public object brand_id { get; set; }
        public int? shipping_amount { get; set; }
        public object pos_id { get; set; }
        public object store_id { get; set; }
        public object integrator_id { get; set; }
        public object platform_id { get; set; }
        public object corporation_id { get; set; }
        public long? collector_id { get; set; }
        public Payer payer { get; set; }
        public object marketplace_owner { get; set; }
        public Metadata metadata { get; set; }
        public AdditionalInfo additional_info { get; set; }
        public Order order { get; set; }
        public string external_reference { get; set; }
        public double? transaction_amount { get; set; }
        public int? transaction_amount_refunded { get; set; }
        public int? coupon_amount { get; set; }
        public object differential_pricing_id { get; set; }
        public object deduction_schema { get; set; }
        public int? installments { get; set; }
        public TransactionDetails transaction_details { get; set; }
        public List<FeeDetail> fee_details { get; set; }
        public List<object> charges_details { get; set; }
        public bool? captured { get; set; }
        public bool? binary_mode { get; set; }
        public object call_for_authorize_id { get; set; }
        public string statement_descriptor { get; set; }
        public Card card { get; set; }
        public string notification_url { get; set; }
        public List<object> refunds { get; set; }
        public string processing_mode { get; set; }
        public object merchant_account_id { get; set; }
        public object merchant_number { get; set; }
        public PointOfInteraction point_of_interaction { get; set; }
    }

    public class Identification
    {
        public string type { get; set; }
        public string number { get; set; }
    }

    public class Phone
    {
        public object area_code { get; set; }
        public object number { get; set; }
        public object extension { get; set; }
    }

    public class Payer
    {
        public object type { get; set; }
        public string id { get; set; }
        public object operator_id { get; set; }
        public string email { get; set; }
        public Identification identification { get; set; }
        public Phone phone { get; set; }
        public object first_name { get; set; }
        public object last_name { get; set; }
        public object entity_type { get; set; }
        public Address address { get; set; }
    }

    public class Metadata
    {
    }

    public class Item
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string picture_url { get; set; }
        public string category_id { get; set; }
        public string quantity { get; set; }
        public string unit_price { get; set; }
    }

    public class Address
    {
        public string zip_code { get; set; }
        public string street_name { get; set; }
        public string street_number { get; set; }
    }

    public class ReceiverAddress
    {
        public string zip_code { get; set; }
        public string state_name { get; set; }
        public string city_name { get; set; }
        public string street_name { get; set; }
        public string street_number { get; set; }
    }

    public class Shipments
    {
        public ReceiverAddress receiver_address { get; set; }
    }

    public class AdditionalInfo
    {
        public List<Item> items { get; set; }
        public Payer payer { get; set; }
        public Shipments shipments { get; set; }
        public object available_balance { get; set; }
        public object nsu_processadora { get; set; }
        public object authentication_code { get; set; }
    }

    public class Order
    {
    }

    public class TransactionDetails
    {
        public object payment_method_reference_id { get; set; }
        public double net_received_amount { get; set; }
        public double total_paid_amount { get; set; }
        public int overpaid_amount { get; set; }
        public object external_resource_url { get; set; }
        public double installment_amount { get; set; }
        public object financial_institution { get; set; }
        public object payable_deferral_period { get; set; }
        public object acquirer_reference { get; set; }
    }

    public class FeeDetail
    {
        public string type { get; set; }
        public double amount { get; set; }
        public string fee_payer { get; set; }
    }

    public class Cardholder
    {
        public string name { get; set; }
        public Identification identification { get; set; }
    }

    public class Card
    {
        public object id { get; set; }
        public string first_six_digits { get; set; }
        public string last_four_digits { get; set; }
        public int expiration_month { get; set; }
        public int expiration_year { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_last_updated { get; set; }
        public Cardholder cardholder { get; set; }
    }

    public class BusinessInfo
    {
        public string unit { get; set; }
        public string sub_unit { get; set; }
    }

    public class PointOfInteraction
    {
        public string type { get; set; }
        public BusinessInfo business_info { get; set; }
    }
}
