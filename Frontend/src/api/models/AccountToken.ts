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
import type { AccountViewModel } from './AccountViewModel';
import {
    AccountViewModelFromJSON,
    AccountViewModelFromJSONTyped,
    AccountViewModelToJSON,
} from './AccountViewModel';

/**
 * 
 * @export
 * @interface AccountToken
 */
export interface AccountToken {
    /**
     * 
     * @type {AccountViewModel}
     * @memberof AccountToken
     */
    user?: AccountViewModel;
    /**
     * 
     * @type {string}
     * @memberof AccountToken
     */
    token?: string | null;
}

/**
 * Check if a given object implements the AccountToken interface.
 */
export function instanceOfAccountToken(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function AccountTokenFromJSON(json: any): AccountToken {
    return AccountTokenFromJSONTyped(json, false);
}

export function AccountTokenFromJSONTyped(json: any, ignoreDiscriminator: boolean): AccountToken {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'user': !exists(json, 'user') ? undefined : AccountViewModelFromJSON(json['user']),
        'token': !exists(json, 'token') ? undefined : json['token'],
    };
}

export function AccountTokenToJSON(value?: AccountToken | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'user': AccountViewModelToJSON(value.user),
        'token': value.token,
    };
}

