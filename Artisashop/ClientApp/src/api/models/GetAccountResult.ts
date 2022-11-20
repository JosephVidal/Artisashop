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
import type { Account } from './Account';
import {
    AccountFromJSON,
    AccountFromJSONTyped,
    AccountToJSON,
} from './Account';

/**
 * 
 * @export
 * @interface GetAccountResult
 */
export interface GetAccountResult {
    /**
     * 
     * @type {Account}
     * @memberof GetAccountResult
     */
    account?: Account;
    /**
     * 
     * @type {Array<string>}
     * @memberof GetAccountResult
     */
    roles?: Array<string> | null;
}

/**
 * Check if a given object implements the GetAccountResult interface.
 */
export function instanceOfGetAccountResult(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function GetAccountResultFromJSON(json: any): GetAccountResult {
    return GetAccountResultFromJSONTyped(json, false);
}

export function GetAccountResultFromJSONTyped(json: any, ignoreDiscriminator: boolean): GetAccountResult {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'account': !exists(json, 'account') ? undefined : AccountFromJSON(json['account']),
        'roles': !exists(json, 'roles') ? undefined : json['roles'],
    };
}

export function GetAccountResultToJSON(value?: GetAccountResult | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'account': AccountToJSON(value.account),
        'roles': value.roles,
    };
}
