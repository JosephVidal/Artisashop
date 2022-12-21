# ArtisashopApi.Model.Account

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** |  | [optional] 
**UserName** | **string** |  | [optional] 
**NormalizedUserName** | **string** |  | [optional] 
**Email** | **string** |  | [optional] 
**NormalizedEmail** | **string** |  | [optional] 
**EmailConfirmed** | **bool** |  | [optional] 
**PasswordHash** | **string** |  | [optional] 
**SecurityStamp** | **string** |  | [optional] 
**ConcurrencyStamp** | **string** |  | [optional] 
**PhoneNumber** | **string** |  | [optional] 
**PhoneNumberConfirmed** | **bool** |  | [optional] 
**TwoFactorEnabled** | **bool** |  | [optional] 
**LockoutEnd** | **DateTime?** |  | [optional] 
**LockoutEnabled** | **bool** |  | [optional] 
**AccessFailedCount** | **int** |  | [optional] 
**Lastname** | **string** |  | 
**Firstname** | **string** |  | 
**ProfilePicture** | **string** |  | [optional] 
**Job** | **string** |  | [optional] 
**Biography** | **string** |  | [optional] 
**Address** | **string** |  | [optional] 
**AddressGPS** | [**GPSCoord**](GPSCoord.md) |  | [optional] 
**CreatedAt** | **DateTime?** |  | [optional] 
**UpdatedAt** | **DateTime?** |  | [optional] 
**Baskets** | [**List&lt;Basket&gt;**](Basket.md) |  | [optional] 
**Bills** | [**List&lt;Bill&gt;**](Bill.md) |  | [optional] 
**Suspended** | **bool** |  | 
**Products** | [**List&lt;Product&gt;**](Product.md) |  | [optional] 
**Validation** | **bool** |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

