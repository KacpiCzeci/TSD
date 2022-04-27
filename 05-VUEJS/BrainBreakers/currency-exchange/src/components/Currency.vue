<template>
    <div id="app" class="container">
	    <div class="row main-container mx-auto">
		    <div class="row title-container no-gutters">
			    <div class="col-10">
			    	<h1 class="title">Currency Exchange</h1>
			    </div>
			    <div class="col-2">
		    		<select class="select-country" @change="updateInputs" v-model="selected">
		    			<option v-for="country in countries">{{country.name}}</option>
		    		</select>
		    	</div>
		    </div>
		
		    <div class="row">
			<!-- input field 1 -->
			    <div class="col">
				    <img class="country-flag" :src="imageSrc + 'flag-australia.png'"/>
				    <h2 class="country-name">Australia</h2>
				    <p>Rate: 1 AUD</p>
				    <input id="currencyInput" class="currency-input" @keyup="calcInput_1(event, countryRate)" :value="calc2">
			    </div>
			<!-- input field 2 -->
			    <div class="col">
				    <template v-for="country in countries">
					    <template v-if="selected === country.name" v-model="countryRate">
						    <img class="country-flag" :src="imageSrc + country.image"/>
						    <h2 class="country-name">{{country.name}}</h2>
						    <p class="">Rate: {{country.rate}} AUD</p>
					    	<input class="currency-input" @keyup="calcInput_2" :value="calc1"><span>{{country.money}}</span>
				    	</template>
			    	</template>
		    	</div>
	    	</div>
    	</div>
    </div>
</template>

<script>
export default{
    name: "Currency",
    data() {
        return {

        }
    },
    methods: {
        onCurrencyChange(e) {

        }
    },
}
</script>