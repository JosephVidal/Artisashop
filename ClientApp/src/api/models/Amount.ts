/* tslint:disable */
/* eslint-disable */
/**
 * API Artichaut
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
import type { Breakdown } from './Breakdown';
import {
    BreakdownFromJSON,
    BreakdownFromJSONTyped,
    BreakdownToJSON,
} from './Breakdown';

/**
 * 
 * @export
 * @interface Amount
 */
export interface Amount {
    /**
     * 
     * @type {string}
     * @memberof Amount
     */
    currencyCode: string;
    /**
     * 
     * @type {number}
     * @memberof Amount
     */
    value: number;
    /**
     * 
     * @type {Breakdown}
     * @memberof Amount
     */
    breakdown: Breakdown;
}

/**
 * Check if a given object implements the Amount interface.
 */
export function instanceOfAmount(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "currencyCode" in value;
    isInstance = isInstance && "value" in value;
    isInstance = isInstance && "breakdown" in value;

    return isInstance;
}

export function AmountFromJSON(json: any): Amount {
    return AmountFromJSONTyped(json, false);
}

export function AmountFromJSONTyped(json: any, ignoreDiscriminator: boolean): Amount {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'currencyCode': json['currencyCode'],
        'value': json['value'],
        'breakdown': BreakdownFromJSON(json['breakdown']),
    };
}

export function AmountToJSON(value?: Amount | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'currencyCode': value.currencyCode,
        'value': value.value,
        'breakdown': BreakdownToJSON(value.breakdown),
    };
}

