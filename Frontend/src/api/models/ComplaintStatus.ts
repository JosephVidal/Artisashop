/* tslint:disable */
/* eslint-disable */
/**
 * API Artisashop
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


/**
 * 
 * @export
 */
export const ComplaintStatus = {
    Open: 'Open',
    Closed: 'Closed'
} as const;
export type ComplaintStatus = typeof ComplaintStatus[keyof typeof ComplaintStatus];


export function ComplaintStatusFromJSON(json: any): ComplaintStatus {
    return ComplaintStatusFromJSONTyped(json, false);
}

export function ComplaintStatusFromJSONTyped(json: any, ignoreDiscriminator: boolean): ComplaintStatus {
    return json as ComplaintStatus;
}

export function ComplaintStatusToJSON(value?: ComplaintStatus | null): any {
    return value as any;
}

