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
import type { DeliveryOption } from './DeliveryOption';
import {
    DeliveryOptionFromJSON,
    DeliveryOptionFromJSONTyped,
    DeliveryOptionToJSON,
} from './DeliveryOption';
import type { State } from './State';
import {
    StateFromJSON,
    StateFromJSONTyped,
    StateToJSON,
} from './State';

/**
 * 
 * @export
 * @interface UpdateBasket
 */
export interface UpdateBasket {
    /**
     * 
     * @type {number}
     * @memberof UpdateBasket
     */
    id?: number;
    /**
     * 
     * @type {number}
     * @memberof UpdateBasket
     */
    quantity: number;
    /**
     * 
     * @type {DeliveryOption}
     * @memberof UpdateBasket
     */
    deliveryOpt: DeliveryOption;
    /**
     * 
     * @type {State}
     * @memberof UpdateBasket
     */
    currentState: State;
}

/**
 * Check if a given object implements the UpdateBasket interface.
 */
export function instanceOfUpdateBasket(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "quantity" in value;
    isInstance = isInstance && "deliveryOpt" in value;
    isInstance = isInstance && "currentState" in value;

    return isInstance;
}

export function UpdateBasketFromJSON(json: any): UpdateBasket {
    return UpdateBasketFromJSONTyped(json, false);
}

export function UpdateBasketFromJSONTyped(json: any, ignoreDiscriminator: boolean): UpdateBasket {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'id': !exists(json, 'id') ? undefined : json['id'],
        'quantity': json['quantity'],
        'deliveryOpt': DeliveryOptionFromJSON(json['deliveryOpt']),
        'currentState': StateFromJSON(json['currentState']),
    };
}

export function UpdateBasketToJSON(value?: UpdateBasket | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'id': value.id,
        'quantity': value.quantity,
        'deliveryOpt': DeliveryOptionToJSON(value.deliveryOpt),
        'currentState': StateToJSON(value.currentState),
    };
}
