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
import type { Basket } from './Basket';
import {
    BasketFromJSON,
    BasketFromJSONTyped,
    BasketToJSON,
} from './Basket';
import type { State } from './State';
import {
    StateFromJSON,
    StateFromJSONTyped,
    StateToJSON,
} from './State';

/**
 * 
 * @export
 * @interface OrderList
 */
export interface OrderList {
    /**
     * 
     * @type {Basket}
     * @memberof OrderList
     */
    item?: Basket;
    /**
     * 
     * @type {Array<State>}
     * @memberof OrderList
     */
    possibleState?: Array<State> | null;
}

/**
 * Check if a given object implements the OrderList interface.
 */
export function instanceOfOrderList(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function OrderListFromJSON(json: any): OrderList {
    return OrderListFromJSONTyped(json, false);
}

export function OrderListFromJSONTyped(json: any, ignoreDiscriminator: boolean): OrderList {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'item': !exists(json, 'item') ? undefined : BasketFromJSON(json['item']),
        'possibleState': !exists(json, 'possibleState') ? undefined : (json['possibleState'] === null ? null : (json['possibleState'] as Array<any>).map(StateFromJSON)),
    };
}

export function OrderListToJSON(value?: OrderList | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'item': BasketToJSON(value.item),
        'possibleState': value.possibleState === undefined ? undefined : (value.possibleState === null ? null : (value.possibleState as Array<any>).map(StateToJSON)),
    };
}

