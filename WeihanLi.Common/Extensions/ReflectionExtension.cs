using System;
using System.Linq;
using System.Reflection;

namespace WeihanLi.Common.Extensions
{
    public static class ReflectionExtension
    {
        /// <summary>An object extension method that gets the first custom attribute.</summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="attribute">The attribute.</param>
        /// <returns>The custom attribute.</returns>
        public static Attribute GetCustomAttribute(this object @this, Type attribute)
        {
            var type = @this.GetType();

            return type.IsEnum ?
                Attribute.GetCustomAttribute(type.GetField(@this.ToString()), attribute) :
                Attribute.GetCustomAttribute(type, attribute);
        }

        /// <summary>
        ///     An object extension method that gets the first custom attribute.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="attribute">The attribute.</param>
        /// <param name="inherit">true to inherit.</param>
        /// <returns>The custom attribute.</returns>
        public static Attribute GetCustomAttribute(this object @this, Type attribute, bool inherit)
        {
            var type = @this.GetType();

            return type.IsEnum ?
                Attribute.GetCustomAttribute(type.GetField(@this.ToString()), attribute, inherit) :
                Attribute.GetCustomAttribute(type, attribute, inherit);
        }

        /// <summary>An object extension method that gets custom attribute.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The custom attribute.</returns>
        public static T GetCustomAttribute<T>(this object @this) where T : Attribute
        {
            var type = @this.GetType();

            return (T)(type.IsEnum ?
                Attribute.GetCustomAttribute(type.GetField(@this.ToString()), typeof(T)) :
                Attribute.GetCustomAttribute(type, typeof(T)));
        }

        /// <summary>
        ///     An object extension method that gets custom attribute.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="inherit">true to inherit.</param>
        /// <returns>The custom attribute.</returns>
        public static T GetCustomAttribute<T>(this object @this, bool inherit) where T : Attribute
        {
            var type = @this.GetType();

            return (T)(type.IsEnum ?
                Attribute.GetCustomAttribute(type.GetField(@this.ToString()), typeof(T), inherit) :
                Attribute.GetCustomAttribute(type, typeof(T), inherit));
        }

        /// <summary>An object extension method that gets custom attribute.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The custom attribute.</returns>
        public static T GetCustomAttribute<T>(this MemberInfo @this) where T : Attribute
        {
            return (T)Attribute.GetCustomAttribute(@this, typeof(T));
        }

        /// <summary>An object extension method that gets custom attribute.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="inherit">true to inherit.</param>
        /// <returns>The custom attribute.</returns>
        public static T GetCustomAttribute<T>(this MemberInfo @this, bool inherit) where T : Attribute
        {
            return (T)Attribute.GetCustomAttribute(@this, typeof(T), inherit);
        }

        /// <summary>An object extension method that gets custom attributes.</summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>An array of object.</returns>
        public static object[] GetCustomAttributes(this object @this)
        {
            return @this.GetCustomAttributes(false);
        }

        /// <summary>
        ///     An object extension method that gets custom attributes.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="inherit">true to inherit.</param>
        /// <returns>An array of object.</returns>
        public static object[] GetCustomAttributes(this object @this, bool inherit)
        {
            var type = @this.GetType();

            return type.IsEnum ?
                type.GetField(@this.ToString()).GetCustomAttributes(inherit) :
                type.GetCustomAttributes(inherit);
        }

        /// <summary>An object extension method that gets custom attributes.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>An array of object.</returns>
        public static T[] GetCustomAttributes<T>(this object @this) where T : Attribute
        {
            var type = @this.GetType();

            return (T[])(type.IsEnum ?
                type.GetField(@this.ToString()).GetCustomAttributes(typeof(T)) :
                type.GetCustomAttributes(typeof(T)));
        }

        /// <summary>
        ///     An object extension method that gets custom attributes.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="inherit">true to inherit.</param>
        /// <returns>An array of object.</returns>
        public static T[] GetCustomAttributes<T>(this object @this, bool inherit) where T : Attribute
        {
            var type = @this.GetType();

            return (T[])(type.IsEnum ?
                type.GetField(@this.ToString()).GetCustomAttributes(typeof(T), inherit) :
                type.GetCustomAttributes(typeof(T), inherit));
        }

        /// <summary>An object extension method that gets custom attributes.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>An array of object.</returns>
        public static T[] GetCustomAttributes<T>(this MemberInfo @this) where T : Attribute
        {
            return (T[])@this.GetCustomAttributes(typeof(T));
        }

        /// <summary>An object extension method that gets custom attributes.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="inherit">true to inherit.</param>
        /// <returns>An array of object.</returns>
        public static T[] GetCustomAttributes<T>(this MemberInfo @this, bool inherit) where T : Attribute
        {
            return (T[])@this.GetCustomAttributes(typeof(T), inherit);
        }

        /// <summary>A T extension method that searches for the public field with the specified name.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="name">The string containing the name of the data field to get.</param>
        /// <returns>
        ///     An object representing the field that matches the specified requirements, if found;
        ///     otherwise, null.
        /// </returns>
        public static FieldInfo GetField<T>(this T @this, string name)
        {
            return @this.GetType().GetField(name);
        }

        /// <summary>
        ///     A T extension method that searches for the specified field, using the specified
        ///     binding constraints.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="name">The string containing the name of the data field to get.</param>
        /// <param name="bindingAttr">
        ///     A bitmask comprised of one or more BindingFlags that specify how the
        ///     search is conducted.
        /// </param>
        /// <returns>
        ///     An object representing the field that matches the specified requirements, if found;
        ///     otherwise, null.
        /// </returns>
        public static FieldInfo GetField<T>(this T @this, string name, BindingFlags bindingAttr)
        {
            return @this.GetType().GetField(name, bindingAttr);
        }

        /// <summary>An object extension method that gets the fields.</summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>An array of field information.</returns>
        public static FieldInfo[] GetFields(this object @this)
        {
            return @this.GetType().GetFields();
        }

        /// <summary>An object extension method that gets the fields.</summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="bindingAttr">The binding attribute.</param>
        /// <returns>An array of field information.</returns>
        public static FieldInfo[] GetFields(this object @this, BindingFlags bindingAttr)
        {
            return @this.GetType().GetFields(bindingAttr);
        }

        /// <summary>
        ///     A T extension method that gets a field value (Public | NonPublic | Instance | Static)
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>The field value.</returns>
        public static object GetFieldValue<T>(this T @this, string fieldName)
        {
            Type type = @this.GetType();
            FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            return field.GetValue(@this);
        }

        /// <summary>
        ///     A T extension method that searches for the public method with the specified name.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="name">The string containing the name of the public method to get.</param>
        /// <returns>
        ///     An object that represents the public method with the specified name, if found; otherwise, null.
        /// </returns>
        public static MethodInfo GetMethod<T>(this T @this, string name)
        {
            return @this.GetType().GetMethod(name);
        }

        /// <summary>
        ///     A T extension method that searches for the specified method whose parameters match the specified argument
        ///     types and modifiers, using the specified binding constraints.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="name">The string containing the name of the public method to get.</param>
        /// <param name="bindingAttr">A bitmask comprised of one or more BindingFlags that specify how the search is conducted.</param>
        /// <returns>
        ///     An object that represents the public method with the specified name, if found; otherwise, null.
        /// </returns>
        public static MethodInfo GetMethod<T>(this T @this, string name, BindingFlags bindingAttr)
        {
            return @this.GetType().GetMethod(name, bindingAttr);
        }

        /// <summary>
        ///     A T extension method that returns all the public methods of the current Type.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>
        ///     An array of MethodInfo objects representing all the public methods defined for the current Type. or An empty
        ///     array of type MethodInfo, if no public methods are defined for the current Type.
        /// </returns>
        public static MethodInfo[] GetMethods<T>(this T @this)
        {
            return @this.GetType().GetMethods();
        }

        /// <summary>
        ///     A T extension method that searches for the methods defined for the current Type, using the specified binding
        ///     constraints.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="bindingAttr">A bitmask comprised of one or more BindingFlags that specify how the search is conducted.</param>
        /// <returns>
        ///     An array of MethodInfo objects representing all methods defined for the current Type that match the specified
        ///     binding constraints. or An empty array of type MethodInfo, if no methods are defined for the current Type, or
        ///     if none of the defined methods match the binding constraints.
        /// </returns>
        public static MethodInfo[] GetMethods<T>(this T @this, BindingFlags bindingAttr)
        {
            return @this.GetType().GetMethods(bindingAttr);
        }

        /// <summary>An object extension method that gets the properties.</summary>
        /// <param name="this">The @this to act on.</param>
        /// <returns>An array of property information.</returns>
        public static PropertyInfo[] GetProperties(this object @this)
        {
            return @this.GetType().GetProperties();
        }

        /// <summary>An object extension method that gets the properties.</summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="bindingAttr">The binding attribute.</param>
        /// <returns>An array of property information.</returns>
        public static PropertyInfo[] GetProperties(this object @this, BindingFlags bindingAttr)
        {
            return @this.GetType().GetProperties(bindingAttr);
        }

        /// <summary>
        ///     A T extension method that gets a property.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="name">The name.</param>
        /// <returns>The property.</returns>
        public static PropertyInfo GetProperty<T>(this T @this, string name)
        {
            return @this.GetType().GetProperty(name);
        }

        /// <summary>
        ///     A T extension method that gets a property.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="name">The name.</param>
        /// <param name="bindingAttr">The binding attribute.</param>
        /// <returns>The property.</returns>
        public static PropertyInfo GetProperty<T>(this T @this, string name, BindingFlags bindingAttr)
        {
            return @this.GetType().GetProperty(name, bindingAttr);
        }

        /// <summary>A T extension method that gets property or field.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="name">The name.</param>
        /// <returns>The property or field.</returns>
        public static MemberInfo GetPropertyOrField<T>(this T @this, string name)
        {
            PropertyInfo property = @this.GetProperty(name);
            if (property != null)
            {
                return property;
            }

            FieldInfo field = @this.GetField(name);
            if (field != null)
            {
                return field;
            }

            return null;
        }

        /// <summary>
        ///     A T extension method that gets property value.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>The property value.</returns>
        public static object GetPropertyValue<T>(this T @this, string propertyName)
        {
            Type type = @this.GetType();
            PropertyInfo property = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            return property.GetValue(@this, null);
        }

        /// <summary>
        ///     An object extension method that executes the method on a different thread, and waits for the result.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="obj">The obj to act on.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="parameters">Options for controlling the operation.</param>
        /// <returns>An object.</returns>
        public static object InvokeMethod<T>(this T obj, string methodName, params object[] parameters)
        {
            Type type = obj.GetType();
            MethodInfo method = type.GetMethod(methodName, parameters.Select(o => o.GetType()).ToArray());

            return method.Invoke(obj, parameters);
        }

        /// <summary>
        ///     An object extension method that executes the method on a different thread, and waits for the result.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="obj">The obj to act on.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="parameters">Options for controlling the operation.</param>
        /// <returns>A T.</returns>
        public static T InvokeMethod<T>(this object obj, string methodName, params object[] parameters)
        {
            Type type = obj.GetType();
            MethodInfo method = type.GetMethod(methodName, parameters.Select(o => o.GetType()).ToArray());

            object value = method.Invoke(obj, parameters);
            return (value is T ? (T)value : default(T));
        }

        /// <summary>
        ///     An object extension method that query if '@this' is attribute defined.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="attributeType">Type of the attribute.</param>
        /// <param name="inherit">true to inherit.</param>
        /// <returns>true if attribute defined, false if not.</returns>
        public static bool IsAttributeDefined(this object @this, Type attributeType, bool inherit)
        {
            return @this.GetType().IsDefined(attributeType, inherit);
        }

        /// <summary>
        ///     An object extension method that query if '@this' is attribute defined.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="inherit">true to inherit.</param>
        /// <returns>true if attribute defined, false if not.</returns>
        public static bool IsAttributeDefined<T>(this object @this, bool inherit) where T : Attribute
        {
            return @this.GetType().IsDefined(typeof(T), inherit);
        }

        /// <summary>
        ///     A T extension method that sets field value.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="value">The value.</param>
        public static void SetFieldValue<T>(this T @this, string fieldName, object value)
        {
            Type type = @this.GetType();
            FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            field.SetValue(@this, value);
        }

        /// <summary>
        ///     A T extension method that sets property value.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="value">The value.</param>
        public static void SetPropertyValue<T>(this T @this, string propertyName, object value)
        {
            Type type = @this.GetType();
            PropertyInfo property = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            property.SetValue(@this, value, null);
        }

        /// <summary>
        ///     A T extension method that query if '@this' is array.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if array, false if not.</returns>
        public static bool IsArray<T>(this T @this)
        {
            return @this.GetType().IsArray;
        }

        /// <summary>
        ///     A T extension method that query if '@this' is class.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if class, false if not.</returns>
        public static bool IsClass<T>(this T @this)
        {
            return @this.GetType().IsClass;
        }

        /// <summary>
        ///     A T extension method that query if '@this' is enum.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if enum, false if not.</returns>
        public static bool IsEnum<T>(this T @this)
        {
            return @this.GetType().IsEnum;
        }

        /// <summary>
        ///     A T extension method that query if '@this' is subclass of.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="type">The Type to process.</param>
        /// <returns>true if subclass of, false if not.</returns>
        public static bool IsSubclassOf<T>(this T @this, Type type)
        {
            return @this.GetType().IsSubclassOf(type);
        }

        /// <summary>
        ///     An Assembly extension method that gets an attribute.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>The attribute.</returns>
        public static T GetAttribute<T>(this Assembly @this) where T : Attribute
        {
            object[] configAttributes = Attribute.GetCustomAttributes(@this, typeof(T), false);

            if (configAttributes != null && configAttributes.Length > 0)
            {
                return (T)configAttributes[0];
            }

            return null;
        }

        /// <summary>
        ///     Retrieves a custom attribute applied to a specified assembly. Parameters specify the assembly and the type of
        ///     the custom attribute to search for.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a reusable collection of modules.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <returns>
        ///     A reference to the single custom attribute of type  that is applied to , or null if there is no such
        ///     attribute.
        /// </returns>
        public static Attribute GetCustomAttribute(this Assembly element, Type attributeType)
        {
            return Attribute.GetCustomAttribute(element, attributeType);
        }

        /// <summary>
        ///     Retrieves a custom attribute applied to an assembly. Parameters specify the assembly, the type of the custom
        ///     attribute to search for, and an ignored search option.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a reusable collection of modules.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <param name="inherit">This parameter is ignored, and does not affect the operation of this method.</param>
        /// <returns>
        ///     A reference to the single custom attribute of type  that is applied to , or null if there is no such
        ///     attribute.
        /// </returns>
        public static Attribute GetCustomAttribute(this Assembly element, Type attributeType, Boolean inherit)
        {
            return Attribute.GetCustomAttribute(element, attributeType, inherit);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to an assembly. Parameters specify the assembly, and the
        ///     type of the custom attribute to search for.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a reusable collection of modules.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <returns>
        ///     An  array that contains the custom attributes of type  applied to , or an empty array if no such custom
        ///     attributes exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this Assembly element, Type attributeType)
        {
            return Attribute.GetCustomAttributes(element, attributeType);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to an assembly. Parameters specify the assembly, the type
        ///     of the custom attribute to search for, and an ignored search option.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a reusable collection of modules.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <param name="inherit">This parameter is ignored, and does not affect the operation of this method.</param>
        /// <returns>
        ///     An  array that contains the custom attributes of type  applied to , or an empty array if no such custom
        ///     attributes exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this Assembly element, Type attributeType, Boolean inherit)
        {
            return Attribute.GetCustomAttributes(element, attributeType, inherit);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to an assembly. A parameter specifies the assembly.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a reusable collection of modules.</param>
        /// <returns>
        ///     An  array that contains the custom attributes applied to , or an empty array if no such custom attributes
        ///     exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this Assembly element)
        {
            return Attribute.GetCustomAttributes(element);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to an assembly. Parameters specify the assembly, and an
        ///     ignored search option.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a reusable collection of modules.</param>
        /// <param name="inherit">This parameter is ignored, and does not affect the operation of this method.</param>
        /// <returns>
        ///     An  array that contains the custom attributes applied to , or an empty array if no such custom attributes
        ///     exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this Assembly element, Boolean inherit)
        {
            return Attribute.GetCustomAttributes(element, inherit);
        }

        /// <summary>
        ///     Determines whether any custom attributes are applied to an assembly. Parameters specify the assembly, and the
        ///     type of the custom attribute to search for.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a reusable collection of modules.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <returns>true if a custom attribute of type  is applied to ; otherwise, false.</returns>
        public static Boolean IsDefined(this Assembly element, Type attributeType)
        {
            return Attribute.IsDefined(element, attributeType);
        }

        /// <summary>
        ///     Determines whether any custom attributes are applied to an assembly. Parameters specify the assembly, the
        ///     type of the custom attribute to search for, and an ignored search option.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a reusable collection of modules.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <param name="inherit">This parameter is ignored, and does not affect the operation of this method.</param>
        /// <returns>true if a custom attribute of type  is applied to ; otherwise, false.</returns>
        public static Boolean IsDefined(this Assembly element, Type attributeType, Boolean inherit)
        {
            return Attribute.IsDefined(element, attributeType, inherit);
        }

        /// <summary>
        ///     Determines whether any custom attributes are applied to a member of a type. Parameters specify the member,
        ///     and the type of the custom attribute to search for.
        /// </summary>
        /// <param name="element">
        ///     An object derived from the  class that describes a constructor, event, field, method, type,
        ///     or property member of a class.
        /// </param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <returns>true if a custom attribute of type  is applied to ; otherwise, false.</returns>
        public static Boolean IsDefined(this MemberInfo element, Type attributeType)
        {
            return Attribute.IsDefined(element, attributeType);
        }

        /// <summary>
        ///     Determines whether any custom attributes are applied to a member of a type. Parameters specify the member,
        ///     the type of the custom attribute to search for, and whether to search ancestors of the member.
        /// </summary>
        /// <param name="element">
        ///     An object derived from the  class that describes a constructor, event, field, method, type,
        ///     or property member of a class.
        /// </param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <param name="inherit">If true, specifies to also search the ancestors of  for custom attributes.</param>
        /// <returns>true if a custom attribute of type  is applied to ; otherwise, false.</returns>
        public static Boolean IsDefined(this MemberInfo element, Type attributeType, Boolean inherit)
        {
            return Attribute.IsDefined(element, attributeType, inherit);
        }

        /// <summary>
        ///     Retrieves a custom attribute applied to a member of a type. Parameters specify the member, and the type of
        ///     the custom attribute to search for.
        /// </summary>
        /// <param name="element">
        ///     An object derived from the  class that describes a constructor, event, field, method, or
        ///     property member of a class.
        /// </param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <returns>
        ///     A reference to the single custom attribute of type  that is applied to , or null if there is no such
        ///     attribute.
        /// </returns>
        public static Attribute GetCustomAttribute(this MemberInfo element, Type attributeType)
        {
            return Attribute.GetCustomAttribute(element, attributeType);
        }

        /// <summary>
        ///     Retrieves a custom attribute applied to a member of a type. Parameters specify the member, the type of the
        ///     custom attribute to search for, and whether to search ancestors of the member.
        /// </summary>
        /// <param name="element">
        ///     An object derived from the  class that describes a constructor, event, field, method, or
        ///     property member of a class.
        /// </param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <param name="inherit">If true, specifies to also search the ancestors of  for custom attributes.</param>
        /// <returns>
        ///     A reference to the single custom attribute of type  that is applied to , or null if there is no such
        ///     attribute.
        /// </returns>
        public static Attribute GetCustomAttribute(this MemberInfo element, Type attributeType, Boolean inherit)
        {
            return Attribute.GetCustomAttribute(element, attributeType, inherit);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to a member of a type. Parameters specify the member, and
        ///     the type of the custom attribute to search for.
        /// </summary>
        /// <param name="element">
        ///     An object derived from the  class that describes a constructor, event, field, method, or
        ///     property member of a class.
        /// </param>
        /// <param name="type">The type, or a base type, of the custom attribute to search for.</param>
        /// <returns>
        ///     An  array that contains the custom attributes of type  applied to , or an empty array if no such custom
        ///     attributes exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this MemberInfo element, Type type)
        {
            return Attribute.GetCustomAttributes(element, type);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to a member of a type. Parameters specify the member, the
        ///     type of the custom attribute to search for, and whether to search ancestors of the member.
        /// </summary>
        /// <param name="element">
        ///     An object derived from the  class that describes a constructor, event, field, method, or
        ///     property member of a class.
        /// </param>
        /// <param name="type">The type, or a base type, of the custom attribute to search for.</param>
        /// <param name="inherit">If true, specifies to also search the ancestors of  for custom attributes.</param>
        /// <returns>
        ///     An  array that contains the custom attributes of type  applied to , or an empty array if no such custom
        ///     attributes exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this MemberInfo element, Type type, Boolean inherit)
        {
            return Attribute.GetCustomAttributes(element, type, inherit);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to a member of a type. A parameter specifies the member.
        /// </summary>
        /// <param name="element">
        ///     An object derived from the  class that describes a constructor, event, field, method, or
        ///     property member of a class.
        /// </param>
        /// <returns>
        ///     An  array that contains the custom attributes applied to , or an empty array if no such custom attributes
        ///     exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this MemberInfo element)
        {
            return Attribute.GetCustomAttributes(element);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to a member of a type. Parameters specify the member, the
        ///     type of the custom attribute to search for, and whether to search ancestors of the member.
        /// </summary>
        /// <param name="element">
        ///     An object derived from the  class that describes a constructor, event, field, method, or
        ///     property member of a class.
        /// </param>
        /// <param name="inherit">If true, specifies to also search the ancestors of  for custom attributes.</param>
        /// <returns>
        ///     An  array that contains the custom attributes applied to , or an empty array if no such custom attributes
        ///     exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this MemberInfo element, Boolean inherit)
        {
            return Attribute.GetCustomAttributes(element, inherit);
        }

        /// <summary>
        ///     Retrieves a custom attribute applied to a module. Parameters specify the module, and the type of the custom
        ///     attribute to search for.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a portable executable file.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <returns>
        ///     A reference to the single custom attribute of type  that is applied to , or null if there is no such
        ///     attribute.
        /// </returns>
        public static Attribute GetCustomAttribute(this Module element, Type attributeType)
        {
            return Attribute.GetCustomAttribute(element, attributeType);
        }

        /// <summary>
        ///     Retrieves a custom attribute applied to a module. Parameters specify the module, the type of the custom
        ///     attribute to search for, and an ignored search option.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a portable executable file.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <param name="inherit">This parameter is ignored, and does not affect the operation of this method.</param>
        /// <returns>
        ///     A reference to the single custom attribute of type  that is applied to , or null if there is no such
        ///     attribute.
        /// </returns>
        public static Attribute GetCustomAttribute(this Module element, Type attributeType, Boolean inherit)
        {
            return Attribute.GetCustomAttribute(element, attributeType, inherit);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to a module. Parameters specify the module, and the type
        ///     of the custom attribute to search for.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a portable executable file.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <returns>
        ///     An  array that contains the custom attributes of type  applied to , or an empty array if no such custom
        ///     attributes exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this Module element, Type attributeType)
        {
            return Attribute.GetCustomAttributes(element, attributeType);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to a module. A parameter specifies the module.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a portable executable file.</param>
        /// <returns>
        ///     An  array that contains the custom attributes applied to , or an empty array if no such custom attributes
        ///     exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this Module element)
        {
            return Attribute.GetCustomAttributes(element);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to a module. Parameters specify the module, and an
        ///     ignored search option.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a portable executable file.</param>
        /// <param name="inherit">This parameter is ignored, and does not affect the operation of this method.</param>
        /// <returns>
        ///     An  array that contains the custom attributes applied to , or an empty array if no such custom attributes
        ///     exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this Module element, Boolean inherit)
        {
            return Attribute.GetCustomAttributes(element, inherit);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to a module. Parameters specify the module, the type of
        ///     the custom attribute to search for, and an ignored search option.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a portable executable file.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <param name="inherit">This parameter is ignored, and does not affect the operation of this method.</param>
        /// <returns>
        ///     An  array that contains the custom attributes of type  applied to , or an empty array if no such custom
        ///     attributes exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this Module element, Type attributeType, Boolean inherit)
        {
            return Attribute.GetCustomAttributes(element, attributeType, inherit);
        }

        /// <summary>
        ///     Determines whether any custom attributes of a specified type are applied to a module. Parameters specify the
        ///     module, and the type of the custom attribute to search for.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a portable executable file.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <returns>true if a custom attribute of type  is applied to ; otherwise, false.</returns>
        public static Boolean IsDefined(this Module element, Type attributeType)
        {
            return Attribute.IsDefined(element, attributeType);
        }

        /// <summary>
        ///     Determines whether any custom attributes are applied to a module. Parameters specify the module, the type of
        ///     the custom attribute to search for, and an ignored search option.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a portable executable file.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <param name="inherit">This parameter is ignored, and does not affect the operation of this method.</param>
        /// <returns>true if a custom attribute of type  is applied to ; otherwise, false.</returns>
        public static Boolean IsDefined(this Module element, Type attributeType, Boolean inherit)
        {
            return Attribute.IsDefined(element, attributeType, inherit);
        }

        /// <summary>
        ///     Retrieves a custom attribute applied to a method parameter. Parameters specify the method parameter, and the
        ///     type of the custom attribute to search for.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a parameter of a member of a class.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <returns>
        ///     A reference to the single custom attribute of type  that is applied to , or null if there is no such
        ///     attribute.
        /// </returns>
        public static Attribute GetCustomAttribute(this ParameterInfo element, Type attributeType)
        {
            return Attribute.GetCustomAttribute(element, attributeType);
        }

        /// <summary>
        ///     Retrieves a custom attribute applied to a method parameter. Parameters specify the method parameter, the type
        ///     of the custom attribute to search for, and whether to search ancestors of the method parameter.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a parameter of a member of a class.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <param name="inherit">If true, specifies to also search the ancestors of  for custom attributes.</param>
        /// <returns>
        ///     A reference to the single custom attribute of type  that is applied to , or null if there is no such
        ///     attribute.
        /// </returns>
        public static Attribute GetCustomAttribute(this ParameterInfo element, Type attributeType, Boolean inherit)
        {
            return Attribute.GetCustomAttribute(element, attributeType, inherit);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to a method parameter. A parameter specifies the method
        ///     parameter.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a parameter of a member of a class.</param>
        /// <returns>
        ///     An  array that contains the custom attributes applied to , or an empty array if no such custom attributes
        ///     exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this ParameterInfo element)
        {
            return Attribute.GetCustomAttributes(element);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to a method parameter. Parameters specify the method
        ///     parameter, and the type of the custom attribute to search for.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a parameter of a member of a class.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <returns>
        ///     An  array that contains the custom attributes of type  applied to , or an empty array if no such custom
        ///     attributes exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this ParameterInfo element, Type attributeType)
        {
            return Attribute.GetCustomAttributes(element, attributeType);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to a method parameter. Parameters specify the method
        ///     parameter, the type of the custom attribute to search for, and whether to search ancestors of the method
        ///     parameter.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a parameter of a member of a class.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <param name="inherit">If true, specifies to also search the ancestors of  for custom attributes.</param>
        /// <returns>
        ///     An  array that contains the custom attributes of type  applied to , or an empty array if no such custom
        ///     attributes exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this ParameterInfo element, Type attributeType, Boolean inherit)
        {
            return Attribute.GetCustomAttributes(element, attributeType, inherit);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to a method parameter. Parameters specify the method
        ///     parameter, and whether to search ancestors of the method parameter.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a parameter of a member of a class.</param>
        /// <param name="inherit">If true, specifies to also search the ancestors of  for custom attributes.</param>
        /// <returns>
        ///     An  array that contains the custom attributes applied to , or an empty array if no such custom attributes
        ///     exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this ParameterInfo element, Boolean inherit)
        {
            return Attribute.GetCustomAttributes(element, inherit);
        }

        /// <summary>
        ///     Determines whether any custom attributes are applied to a method parameter. Parameters specify the method
        ///     parameter, and the type of the custom attribute to search for.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a parameter of a member of a class.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <returns>true if a custom attribute of type  is applied to ; otherwise, false.</returns>
        public static Boolean IsDefined(this ParameterInfo element, Type attributeType)
        {
            return Attribute.IsDefined(element, attributeType);
        }

        /// <summary>
        ///     Determines whether any custom attributes are applied to a method parameter. Parameters specify the method
        ///     parameter, the type of the custom attribute to search for, and whether to search ancestors of the method
        ///     parameter.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a parameter of a member of a class.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <param name="inherit">If true, specifies to also search the ancestors of  for custom attributes.</param>
        /// <returns>true if a custom attribute of type  is applied to ; otherwise, false.</returns>
        public static Boolean IsDefined(this ParameterInfo element, Type attributeType, Boolean inherit)
        {
            return Attribute.IsDefined(element, attributeType, inherit);
        }
    }
}