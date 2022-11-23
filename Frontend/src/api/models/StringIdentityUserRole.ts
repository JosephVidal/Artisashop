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
 * @interface StringIdentityUserRole
 */
export interface StringIdentityUserRole {
    /**
     * 
     * @type {string}
     * @memberof StringIdentityUserRole
     */
    userId?: string | null;
    /**
     * 
     * @type {string}
     * @memberof StringIdentityUserRole
     */
    roleId?: string | null;
}

/**
 * Check if a given object implements the StringIdentityUserRole interface.
 */
export function instanceOfStringIdentityUserRole(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function StringIdentityUserRoleFromJSON(json: any): StringIdentityUserRole {
    return StringIdentityUserRoleFromJSONTyped(json, false);
}

export function StringIdentityUserRoleFromJSONTyped(json: any, ignoreDiscriminator: boolean): StringIdentityUserRole {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'userId': !exists(json, 'userId') ? undefined : json['userId'],
        'roleId': !exists(json, 'roleId') ? undefined : json['roleId'],
    };
}

export function StringIdentityUserRoleToJSON(value?: StringIdentityUserRole | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'userId': value.userId,
        'roleId': value.roleId,
    };
}
