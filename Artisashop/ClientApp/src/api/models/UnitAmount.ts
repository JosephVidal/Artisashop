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

import { exists, mapValues } from '../runtime';
/**
 * 
 * @export
 * @interface UnitAmount
 */
export interface UnitAmount {
    /**
     * 
     * @type {string}
     * @memberof UnitAmount
     */
    currencyCode?: string | null;
    /**
     * 
     * @type {number}
     * @memberof UnitAmount
     */
    value?: number;
}

/**
 * Check if a given object implements the UnitAmount interface.
 */
export function instanceOfUnitAmount(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function UnitAmountFromJSON(json: any): UnitAmount {
    return UnitAmountFromJSONTyped(json, false);
}

export function UnitAmountFromJSONTyped(json: any, ignoreDiscriminator: boolean): UnitAmount {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'currencyCode': !exists(json, 'currencyCode') ? undefined : json['currencyCode'],
        'value': !exists(json, 'value') ? undefined : json['value'],
    };
}

export function UnitAmountToJSON(value?: UnitAmount | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'currencyCode': value.currencyCode,
        'value': value.value,
    };
}

